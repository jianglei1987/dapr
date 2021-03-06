# [发布订阅](https://docs.microsoft.com/zh-cn/dotnet/architecture/dapr-for-net-developers/publish-subscribe)
# 解决的问题
    + 需要消息队列的场景
    + 将消息队列和业务分离

# 工作原理
## 发布:
```
    http://localhost:<dapr-port>/v1.0/publish/<pub-sub-name>/<topic>
```
+ dapr-port：Dapr 正在侦听的端口号。
+ pub-sub-name： Dapr 发布/订阅组件的名称。
+ method-name：消息要发布到的主题的名称。
## 订阅：
```
http://localhost:<appPort>/dapr/subscribe
```
+ appPort：Dapr 正在侦听的端口号。

## 消息发布
+ Dapr将不同的消息框架进行抽象和封装，提供了一个与平台无关的API框架。
+ 消息格式：[CloudEvents 1.0 规范](https://github.com/cloudevents/spec/tree/v1.0)
```json
{
    "specversion" : "1.0",
    "type" : "xml.message",
    "source" : "https://example.com/message",
    "subject" : "Test XML Message",
    "id" : "id-1234-5678-9101",
    "time" : "2020-09-23T06:23:21Z",
    "datacontenttype" : "text/xml",
    "data" : "<note><to>User1</to><from>user2</from><message>hi</message></note>"
}
```

## 消息订阅
### 声明方式
```yaml
apiVersion: dapr.io/v1alpha1
kind: Subscription
metadata:
  name: myevent-subscription
spec:
  topic: test_topic  //主题
  route: /TestPubSub //路由
  pubsubname: pubsub //名称
scopes:
- frontend　　　　　　 //为该应用启用订阅
```
### 编程方式

# Dapr.NET SDK的使用

```C#
var data = new OrderData
{
  orderId = "123456",
  productId = "67890",
  amount = 2
};

var daprClient = new DaprClientBuilder().Build();

//pubsub：实现消息代理的Dapr组件名称
//newOrder：消息主题
//data：具体的消息数据
await daprClient.PublishEventAsync<OrderData>("pubsub", "newOrder", data);
```
```C#
//发布

//pubsub：实现消息代理的Dapr组件名称
//newOrder：消息主题
[Topic("pubsub", "newOrder")]
[HttpPost("/orders")]
public async Task<ActionResult> CreateOrder(Order order)
```
```C#
//依赖注入
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddDapr();
```
```C#
//管道加入中间件
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//CloudEvents中间件添加到 ASP.NET Core 中间件管道的调用
//CloudEvents 是标准化的消息传递格式，提供了一种跨平台描述事件信息的常用方法
app.UseCloudEvents();
app.MapControllers();
//添加Dapr发布和订阅
app.MapSubscribeHandler();
```
# Dapr支持的发布订阅组件
+ Apache Kafka
+ Azure 事件中心
+ Azure 服务总线
+ AWS SNS/SQS
+ GCP Pub/Sub
+ Hazelcast
+ MQTT
+ NATS
+ Pulsar
+ RabbitMQ
+ Redis Streams

# 配置
在Dapr配置文件中添加发布/订阅组件
```C#
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub-rq
spec:
  type: pubsub.rabbitmq
  version: v1
  metadata:
  - name: host
    value: "amqp://localhost:5672"
  - name: durable
    value: true
```