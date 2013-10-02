<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="WebApplication.ContactForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<table>
    <tr>
    FirstName</td>
    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>LastName</td>
    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Address</td>
    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>City</td>
    <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>State</td>
    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Zip</td>
    <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
    </tr>

</table>

        <br/>
        <br/>

        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
    
    </div>
        
        <div>
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.Contact" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Business.ContactManager" UpdateMethod="Update"></asp:ObjectDataSource>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" SortExpression="ContactID" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
