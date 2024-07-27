using AutoMapper;
using ExamenSegundaUnidad.Database.Context;
using ExamenSegundaUnidad.Database.Entity;
using ExamenSegundaUnidad.Dtos.Amortization;
using ExamenSegundaUnidad.Dtos.Common;
using ExamenSegundaUnidad.Dtos.New;
using ExamenSegundaUnidad.Helpers;
using ExamenSegundaUnidad.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExamenSegundaUnidad.Service
{
    public class ProspectsService : IProspectsService
    {
        private readonly ProjectServiceDbContext _context;
        private readonly ILogger<ProspectsService> _logger;
        private readonly IMapper _mapper;
      

        public ProspectsService(ProjectServiceDbContext context, ILogger<ProspectsService> logger, IMapper mapper)
        {
            this._context = context;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<ProspectDto>> CreateProspectAsync(ProspectCreateDto dto)
        {
            ProspectsEntity prospectEntity = _mapper.Map<ProspectsEntity>(dto);

            // TO DO - VERIFICAR QUE EL CLIENTE EXISTE Y SI EXISTE BUSCAR SU ID POR MEDIO DEL NOMBRE

            //Sino Le asigna un id(Cliente) que nos ayudará a encontrar luego

     
            var prospectDto = _mapper.Map<ProspectDto>(prospectEntity);

            _context.Prospects.Add(prospectEntity);

            // Guardar los cambios para obtener el `loan_id` generado
            await _context.SaveChangesAsync();

            // Obtener el `loan_id` generado
            Guid loanId = prospectEntity.Id;
            await CalculateAmortizationAsync(dto, loanId);

            
            return new ResponseDto<ProspectDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Prospecto Generado correctamete",
                AmortizationPlan = prospectDto

            };

            

        }
        // Realizar las Operaciones del la Amortizacion para volcar datos a la tabla de Amortizaciones [Partes]
        private async Task CalculateAmortizationAsync(ProspectCreateDto dto, Guid loanId)
        {
            // inicializamos las variblea a usar dentro de la tabla 
            var loanAmount= dto.LoanAmount;
            // Capital Pendiente
            var pendingCapital = 0.0;
            // Interes Anual
            var interestRate = dto.InterestRate/100;
            // Interes de un mes especifico
            var currentInterest = 0.0;
            // cuota 
            var currentInstallment = 0.0;
            // Couta con SVSD
            var currentInsuranceOverDebt = 0.0;
            // Couta sin SVSD
            var currentNoInsuranceOverDebt = 0.0;
            // SobreCargo SVSD
            var currentInsuranceOverDebtCharge = 0.0;
            // interes mensual
            double montlyInterestRate;




            for (int i = 0; i < dto.Term; i++)

            {


                var amortizationEntity = new AmortizationDataEntity
                {
                    AmortizationId = new Guid(),
                    LoanId = loanId,
                    InstallmentNumber = i,

                };
                

                if (i != 0)
                {
                    var newDate = dto.FirstPaymentDate.AddMonths(i);
                    var newDays = (dto.FirstPaymentDate.AddMonths(i) - dto.FirstPaymentDate.AddMonths(i - 1)).Days;

                    
                   
                    // Encontrar la cuota sin SVSD - Igual para todos
                    montlyInterestRate = interestRate / ((360 * 12)/365);
                    var sum = 1 + montlyInterestRate;
                    var pow = Math.Pow(sum, - montlyInterestRate);

                    
                    currentNoInsuranceOverDebt = loanAmount / ((1 - pow) / montlyInterestRate);

                    // Encontramos el Interes Acctual  // [Pending Capital = Saldo Principal ]
                    currentInterest = currentNoInsuranceOverDebt * interestRate / 360 * newDays;

                    // definimos la cuota a Pagar 
                    currentInstallment = currentNoInsuranceOverDebt - currentInterest;

                    //SobreCargo DE SEGURO (SVSD Mes )El Seguro de Vida Sobre Deuda 
                    currentInsuranceOverDebtCharge = pendingCapital * 0.15 / 100;
                    // si es menor que $2 se redondearia a 2 (Según documento)
                    if (currentInsuranceOverDebtCharge < 2.00)
                    {
                        currentInsuranceOverDebtCharge = 2.00;
                    }

                    // Cuota a pagar con SVSD Deberá ser el [Cuota sin SVSD + Cuota]
                    currentInsuranceOverDebt = currentNoInsuranceOverDebt + currentInsuranceOverDebtCharge;

                    // La Cuota sin Seguro Sera El saldo principal(MES ANTERIOR - CUOTA DE SEGURO)
                    currentNoInsuranceOverDebt = pendingCapital - currentInsuranceOverDebtCharge;

                    // Actualiza el Saldo Pendiente
                    pendingCapital = pendingCapital - currentInstallment;

                   
                     amortizationEntity = new AmortizationDataEntity
                     {
                         PaymentDate = newDate,
                         Days = newDays,
                         PrincipalBalance = pendingCapital,
                         Interest = currentInterest,
                         Installment = currentInstallment,
                         LifeInsuranceOverDebt = currentInsuranceOverDebt,
                         LvPaymentNoLinsurance = currentNoInsuranceOverDebt,
                         LvPayment_Linsurance = currentInsuranceOverDebt,
                     };


                }
                else
                {
                    amortizationEntity = new AmortizationDataEntity
                    {
                        PaymentDate = dto.DisbursmentDate,
                        Days = 0,
                        PrincipalBalance = pendingCapital,
                        Interest = currentInterest,
                        Installment = currentInstallment,
                        LifeInsuranceOverDebt = currentInsuranceOverDebt,
                        LvPaymentNoLinsurance =currentNoInsuranceOverDebt,
                        LvPayment_Linsurance = currentInsuranceOverDebt,

                    };
                    



                    
                }
                _context.AmortizationData.Add(amortizationEntity);
                await _context.SaveChangesAsync();
            }
            
        }

        // Ira a buscar a a la tabla de las [Partes (de amortizacion por id y ordenarlas en una lista)]
        //private async Task<List<ProspectDto>> ReadCategoriesFromFileAsync()
        //{
        //    return 
        //}







    }

    internal record struct NewStruct(double Item1, double Item2)
    {
        public static implicit operator (double, double)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((double, double) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
