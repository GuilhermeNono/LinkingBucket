using System.Text.Json;
using LinkBucket.Helper;
using LinkBucket.Model.Response;
using LinkBucket.Refit.Premios;
using LinkBucket.SecretVariables;

var service = new PremiosService();

var file = await File.ReadAllTextAsync(
    @"C:\Builds\LinkBucket\LinkBucket\SecretVariables\SoapResponse.txt");

var restProduct = await service.GetProductDetail(PremiosVariables.Sku);
var soapProducts = await SoapHelper.DeserializeAsync<ProductWrapper>(file);

Console.WriteLine(JsonSerializer.Serialize(restProduct));
Console.WriteLine(JsonSerializer.Serialize(soapProducts));