using Newtonsoft.Json;

namespace ExamenSegundaUnidad.Dtos.Common
{
    public class ResponseDto<T>
    {
        
          public T AmortizationPlan { get; set; }
          public string Message { get; set; }

          [JsonIgnore]
          public int StatusCode { get; set; }

          public bool Status { get; set; }


        
    }
}
