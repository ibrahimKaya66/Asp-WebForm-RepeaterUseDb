<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexRepeater.aspx.cs" Inherits="Asp_WebForm_RepeaterWithDb.IndexRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="container">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="Repeater1_ItemCreated">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Adı</th>
                                <th>Soyadı</th>
                                <th>Şehri</th>
                                <th>Maaşı</th>
                                <th>Güncelle</th>
                                <th>Sil</th>
                            </tr>
                           
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <th><%# Eval("Id") %></th>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("City") %></td>
                            <td><%# Eval("Salary") %></td>
                            <td>
                                <asp:HyperLink ID="HyperEdit" runat="server" CssClass="btn btn-success" NavigateUrl='<%# "~/Edit.aspx?Id=" +Eval("Id") %>'>Güncelle

                                </asp:HyperLink></td>
                            <td>
                                <asp:HyperLink ID="HyperDelete" runat="server" CssClass="btn btn-danger" NavigateUrl='<%# "~/Delete.aspx?Id=" +Eval("Id") %>'>Sil

                                </asp:HyperLink></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                    <asp:Label ID="lblCount" runat="server" Text="Label"></asp:Label>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
