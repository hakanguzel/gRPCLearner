using Grpc.Net.Client;
using gRPCServer.Protos;

var data = new GetProductByIdModel { ProductId = 2 };
var grpcChannel = GrpcChannel.ForAddress("https://localhost:7204");
var client = new Product.ProductClient(grpcChannel);
var response = await client.GetProductByIdAsync(data);
Console.WriteLine(response);
Console.ReadLine();
using (var clientData = client.GetAllProducts(new GetAllProductsRequest()))
{
    while (await clientData.ResponseStream.MoveNext(new System.Threading.CancellationToken()))
    {
        var thisProduct = clientData.ResponseStream.Current;
        Console.WriteLine(thisProduct);
    }
}
Console.ReadLine();