using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiDemo.Controllers.Requests;

public class UpdateDeviceRequest
{
    [SwaggerSchema("設備ID")]
    [Required(ErrorMessage = "設備ID不能為空")]
    public string Id { get; set; }

    // [JsonPropertyName("device_name")]
    [SwaggerSchema("設備名稱")]
    [Required(ErrorMessage = "設備名稱不能為空")]
    [StringLength(100, ErrorMessage = "設備名稱不能超過50個字符")]
    public string Name { get; set; }

    // [JsonPropertyName("device_type")]
    [SwaggerSchema("設備種類")]
    [Required(ErrorMessage = "設備種類不能為空")]
    [StringLength(50, ErrorMessage = "設備種類不能超過50個字符")]
    public string Type { get; set; }

    // [JsonPropertyName("access_token")]
    [SwaggerSchema("訪問令牌")]
    [Required(ErrorMessage = "訪問令牌不能為空")]
    [StringLength(100, ErrorMessage = "訪問令牌不能超過100個字符")]
    public string AccessToken { get; set; }

    // [JsonPropertyName("device_label")]
    [SwaggerSchema("設備標籤")]
    [Required(ErrorMessage = "設備標籤不能為空")]
    [StringLength(200, ErrorMessage = "設備標籤不能超過100個字符")]
    public string Label { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}