# [状态管理](https://docs.microsoft.com/zh-cn/dotnet/architecture/dapr-for-net-developers/state-management)

# 解决的问题
+ 当前的程序需要支持不同的数据存储类型
+ 访问、更新数据需要不同的一致性级别
+ 解决多用户同一时间更新数据

# 工作原理
+ 应用程序和Dapr边车交互来查询存储键值数据。然后，边车API调用一个可配置的状态存储组件来持久化数据，API支持HTTP、gRPC协议。

  `http://localhost:<dapr-port>/v1.0/state/<store-name>/`
  + dapr-port：Dapr监听的端口号
  + store-name：存储组件的名字

# 一致性
# 事务
# 并发
# dapr SDK 的使用
# asp.net core 的集成
# 支持的状态存储组件
# 配置
```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    value: ""
  - name: actorStateStore
    value: "true"
```


