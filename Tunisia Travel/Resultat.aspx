<%@ Page Title="" Language="C#" MasterPageFile="~/Resultat.Master" AutoEventWireup="true" CodeBehind="Resultat.aspx.cs" Inherits="Tunisia_Travel.WebForm5" %>
<asp:Content ID="connexion" ContentPlaceHolderID="connexion" runat="server">
    <asp:LoginView ID="utilisateur" runat="server">
        <LoggedInTemplate>
             <asp:LoginName ID="msg" runat="server" FormatString="Bonjour {0} !"/><br />
             <asp:HyperLink ID="Hyperlnk" runat="server" NavigateUrl="/Users/Profil.aspx#profil">Votre profil</asp:HyperLink><br />
             <asp:LoginStatus ID="satut" runat="server" />
        </LoggedInTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="admin">
                <ContentTemplate>
                <asp:LoginName ID="msg" runat="server" FormatString="Bonjour {0} !"/><br />
                <asp:HyperLink ID="Hyperlien" runat="server" NavigateUrl="/Admin/Administration.aspx#Admino">Administration</asp:HyperLink><br />
                <asp:HyperLink ID="Hyperlnk" runat="server" NavigateUrl="/Users/Profil.aspx#profil">Votre profil</asp:HyperLink><br />
             <asp:LoginStatus ID="satut" runat="server" />
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <AnonymousTemplate>
            <asp:Login ID="cnx" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
            BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="0.8em" ForeColor="#333333" Height="109px" Width="289px" 
                DestinationPageUrl="~/Accueil.aspx">
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <LayoutTemplate>
                    <table border="0" cellpadding="4" cellspacing="0" 
                        style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" style="height:109px;width:289px;">
                                    <tr>
                                        <td align="center" colspan="2" 
                                            style="color:White;background-color:#153481;font-size:0.9em;font-weight:bold;">
                                            
 Se connecter</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nom d&#39;utilisateur&nbsp;:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="Un nom d'utilisateur est requis." 
                                                ToolTip="Un nom d'utilisateur est requis." ValidationGroup="ctl03$cnx">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mot de passe&nbsp;:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Password" ErrorMessage="Un mot de passe est requis." 
                                                ToolTip="Un mot de passe est requis." ValidationGroup="ctl03$cnx">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" 
                                                Text="Mémoriser le mot de passe." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">

                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../Inscription.aspx" Text="Pas encore inscrit">Pas encore inscrit</asp:HyperLink>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Text="Se connecter" 
                                                ValidationGroup="ctl03$cnx" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <TitleTextStyle BackColor="#153481" Font-Bold="True" Font-Size="0.9em" 
                ForeColor="White" />
            </asp:Login>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>
<asp:Content ID="Reslt" ContentPlaceHolderID="Reslt" runat="server">

    <asp:SqlDataSource ID="RslSearchs" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CnxOffres %>" 
        SelectCommand="SELECT [idOffre], [titreOffre], [photo], [prix] FROM [Offres] WHERE (([typeOffre] = @typeOffre) AND ([destination] = @destination) AND ([categorie] = @categorie))">
        <SelectParameters>
            <asp:QueryStringParameter Name="typeOffre" QueryStringField="typeOffre" 
                Type="Boolean" />
            <asp:QueryStringParameter Name="destination" QueryStringField="destination" 
                Type="Int32" />
            <asp:QueryStringParameter Name="categorie" QueryStringField="categorie" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="StlListSearch" runat="server" DataSourceID="RslSearchs" 
        RepeatColumns="4" HorizontalAlign="Center" BorderColor="#14327B">
        <ItemTemplate> 
        <table border="2" bordercolor="#14327b" rules=none  width="243" height="90">
                <td rowspan="3"><asp:Image ID="Image1" runat="server" ImageURL='<%# Eval("photo") %>'                  Width="90px" Height="65" />
                </td>
                <td height="50">    
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("titreOffre") %>' Font-Bold="True"></asp:Label>
                </td>
                <tr><td><asp:Label ID="Label1" runat="server" Text='<%# Eval("prix") %>'></asp:Label></td></tr>
                <tr><td align="right"><a href="Offre.aspx?idOffre=<%# Eval("idOffre") %>#dtlsO">Détails</a></td></tr>
            </tr> 
        </table>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>