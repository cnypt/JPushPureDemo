<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PushInfo.aspx.cs" Inherits="JPushPureDemo.WebForm.PushInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>推送对象：<asp:TextBox ID="txt_alias" runat="server"></asp:TextBox></td>
                    <td>
                        推送内容：<asp:TextBox ID="txt_message1" runat="server"></asp:TextBox>
                        </td>
                    <td>
                        <asp:Button ID="btn_Push" runat="server" Text="立即发送普通推送" OnClick="btn_Push_Click" />
                    </td>
                </tr>
                <tr>
                    <td>推送对象：<asp:TextBox ID="txt_alias2" runat="server"></asp:TextBox></td>
                    <td>
                        推送内容：<asp:TextBox ID="txt_message2" runat="server"></asp:TextBox>
                        </td>
                    <td>
                        <asp:Button ID="btn_Push2" runat="server" Text="立即发送定时推送" OnClick="btn_Push2_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
