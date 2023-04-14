using System.Text.Json.Serialization;


public class ApiResponse
{
    [JsonPropertyName("predictedValue")]
  
    public string PredictedValue { get; set; }
}
