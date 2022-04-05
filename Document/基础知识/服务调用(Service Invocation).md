# [服务调用](https://docs.microsoft.com/zh-cn/dotnet/architecture/dapr-for-net-developers/service-invocation)

# 解决的问题
+ 定位其他服务
+ 安全地调用服务
+ 处理重试异常

# 工作原理
    + Dapr边车相互之间注册信息
    + 每一个应用程序只需要跟自己的边车通信即可 

`http://localhost:<dapr-port>/v1.0/invoke/<application-id>/method/<method-name>`
+ dapr-port：Dapr 正在侦听的 HTTP 端口。
+ application-id：要调用的服务的应用程序 ID。
+ method-name：要在远程服务上调用的方法的名称。

# Dapr.NET SDK的使用

+ 使用方法
    + HttpClient 调用 HTTP 服务
        ```C#
        var httpClient = DaprClient.CreateInvokeHttpClient();
        await httpClient.PostAsJsonAsync("http://orderservice/submit", order);
        ```
        + orderservice 表示调用服务
        ```C#
        public class OrderServiceClient : IOrderServiceClient
        {
            private readonly HttpClient _httpClient;

            public OrderServiceClient(HttpClient httpClient)
            {
                _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            }

            public async Task SubmitOrder(Order order)
            {
                var response = await _httpClient.PostAsJsonAsync("submit", order);
                response.EnsureSuccessStatusCode();
            }
        }
        ```
        +  建议使用方法
    + DaprClient 调用 HTTP 服务
        ```C#
        var daprClient = new DaprClientBuilder().Build();
        try
        {
            var confirmation =
                await daprClient.InvokeMethodAsync<Order, OrderConfirmation>(
                    "orderservice", "submit", order);
        }
        catch (InvocationException ex)
        {
            // Handle error
        }
        ```
        ```C#
        //简单的HTTP调用
        var catalogItems = await daprClient.InvokeMethodAsync<IEnumerable<CatalogItem>>(HttpMethod.Get, "catalogservice", "items");
        ```
        ```C#
        //复杂的HTTP调用
        var request = daprClient.CreateInvokeMethodRequest("orderservice", "submit", order);
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

        //返回方法一
        var orderConfirmation = await daprClient.InvokeMethodAsync<OrderConfirmation>(request);

        //返回方法二
        var response = await daprClient.InvokeMethodWithResponseAsync(request);
        response.EnsureSuccessStatusCode();
        var orderConfirmation = response.Content.ReadFromJsonAsync<OrderConfirmation>();
        ```
    + DaprClient 调用 gRPC 服务
        ```C#
        var daprClient = new DaprClientBuilder().Build();
        try
        {
            var confirmation = await daprClient.InvokeMethodGrpcAsync<Order, OrderConfirmation>("orderservice", "submitOrder", order);
        }
        catch (InvocationException ex)
        {
            // Handle error
        }
        ```
        + gRPC跟HTTP调用方法不一样InvokeMethodGrpcAsync，其他一直
# 配置
```C#
apiVersion: dapr.io/v1alpha1
kind: Configuration
metadata:
  name: dapr-config
spec:
  nameResolution:
    component: "consul"
    configuration:
      selfRegister: true
```
