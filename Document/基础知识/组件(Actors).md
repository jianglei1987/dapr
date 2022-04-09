# [执行组件](https://docs.microsoft.com/zh-cn/dotnet/architecture/dapr-for-net-developers/actors)

# 特征
 + 独立的计算和状态单元
 + 彼此之间完全隔离，不共享内存
 + 彼此之间可以传递消息
 + 单线程模型

# 解决的问题
 + 跨语言平台调用

# 工作原理
```
http://localhost:<daprPort>/v1.0/actors/<actorType>/<actorId>/
```
+ daprPort Dpar：监听端口号
+ actorType：组件类型
+ actorId：调用组件id

Dapr 边车管理组件运行的时间、运行的方式、运行的地址，处理里组件之间的消息等。当组件一段时间没有被使用，运行时会停用当前组件，并释放内存。所有的状态数据会被持久化保存，当当前组件再次被激活时，可以重新加载状态数据。
Dapr 使用一个空闲的计数器来决定