API測試配置
1.添加nuget第三方程序包：webapitestclient
2.在\Areas\HelpPage\Views\Help\Api.cshtml 添加
@Html.DisplayForModel("TestClientDialogs")
    @section Scripts {
        <link type ="text/css" href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
        @Html.DisplayForModel("TestClientReferences")
    }
