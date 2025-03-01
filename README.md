# gocqhttp-CSharp

gocqhttp-CSharp 是一个使用 C# 编写的 QQ 机器人客户端，基于 gocqhttp 实现。

> 这是一个从我初三开始写的一个项目，初衷是锻炼自己，也是想拥有一个自己的QQ机器人。其前身是gocqhttp-C，现在这个是C#的可视化版本。由于中考成绩不佳，我只能到一所私立的寄宿学校读书，平时只有半月假时有时间在家敲敲代码，到了高三就没回过几次家了，所以项目基本搁置了。知道高考完才开始重新开发，但时间过了这么久，我对这个项目的主体功能发开基本已经完成了，只剩下了一些可有可无的功能尚未完成，以后这个项目我大概不会再碰了，算是我从初一开始学编程到现在大专也选择计算机专业这一过程的一个逗号。说实话我对这个项目还挺满意的~~（虽说写的不怎么样）~~，但以后我打算从事游戏方便的开发，所以开始学习unity等一些游戏引擎了，希望自己能不忘初心吧

## 使用须知

- 本项目最初是为`gocqhttp`开发的C#可视化框架，现已修改可以应用于`NapCatQQ`
- 本框架仍有部分功能为实现，比如禁用的功能，但框架已经写好，如果有需要可以自行编写

## 特性

- 支持多种消息类型（文本、图片、语音等）
- 通过事件驱动，可自定义事件响应，可拓展性强
- 框架通过json储存的信息调用API，易用性高

## 安装

1. 克隆仓库：
    ```bash
    git clone https://github.com/yourusername/gocqhttp-CSharp.git
    ```
2. 进入项目目录：
    ```bash
    cd gocqhttp-CSharp
    ```
3. 安装依赖：
    ```bash
    dotnet restore
    ```
4. 编译项目：
    ```bash
    dotnet build
    ```

## 框架使用

1. 配置 `config.json` 文件，填写 QQ 账号和 gocqhttp 相关配置（可在编译运行后在设置里配置）。

2. 使用自定义事件(消息事件示例)
    1.	定义自定义事件处理函数：
        - 创建一个新的类 `CustomMessageEvent`，继承自 `MessageEventClass`。实现 `MessageEventClass` 的抽象方法 `MessageArrived`，在该方法中编写自定义的消息处理逻辑。

    2.	注册自定义事件处理函数：
        - 在 `GocqhttpEvent` 类的实例化代码中，调用 `RegisterMessageFunc` 方法，将自定义的消息事件处理函数注册到事件处理列表中。    

        - `RegisterMessageFunc` 方法的参数包括事件名称、匹配条件（可以使用正则表达式）和自定义的事件处理函数实例。
    
    通过以上步骤，您可以在 `GocqhttpEvent` 类中添加自定义的事件处理函数，并在接收到相应的事件时触发自定义的处理逻辑。

3. 使用API：
    - 使用静态方法`Gocqhttp.Send()`可以调用API，参数为`API名[string]，···[object[]]（API参数，按照gocqhttp文档的顺序，具体可看APIs.json文件）`
    - 使用静态方法`Gocqhttp.Send()`可直接向`NapCat`发送原始消息，参数为`消息[string]`

## 贡献

欢迎贡献代码！请先 fork 项目，然后提交 pull request。

## 许可证

本项目使用 MIT 许可证。详情请参阅 [LICENSE](LICENSE) 文件。

## 联系

如果有任何问题，请通过 [issues](https://github.com/yourusername/gocqhttp-CSharp/issues) 提交。
