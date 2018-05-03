<%@ Page Title="" Language="C#" MasterPageFile="~/TimeClockMaster.Master" AutoEventWireup="true" CodeBehind="TimeClock.aspx.cs" Inherits="MarshfieldTimeClock_V1._1.TimeClock" %>


<%--Title--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Marshfield TimeClock</title>
     <style type="text/css">
        /*#btn-time{
            background-color: #1f3576;
        }*/
    </style>

</asp:Content>



<%--Main--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--   <form id="form1" runat="server">--%>

    <div id="InteractivePage">
       <div id="timeClock">
           <br />
           <h2 id="timeClockHeader"> Time Clock </h2>
           <br />
       </div>
        <div id="Time">
            <asp:TextBox ID="txtBxDisplayTime" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtBxDisplayDay" runat="server" ></asp:TextBox>
        </div>
        <div id="dropDown">
            <br />
            <br />
            <asp:DropDownList ID="drpDwnWorkId" runat="server" OnSelectedIndexChanged="drpDwnWorkId_SelectedIndexChanged" OnTextChanged="drpDwnWorkId_SelectedIndexChanged" Height="24px" Width="124px" >
                
            </asp:DropDownList>
            <br />
            <br />
            <asp:CheckBox ID="chkBxLunch" runat="server" Font-Bold="True" Font-Names="monospace" Font-Size="15px" ForeColor="#1F3576" Text=" Worked Through Lunch" />
            <br />
            <br />
            <asp:Button ID="btnChangeRole" runat="server" Text="Change Role" OnClick="btnChangeRole_Click"/>
            <br />
            <br />
        </div>
        <div id="ClockInOut">
            <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnClockIn" runat="server" Text="Clock In" OnClick="btnClockIn_Click"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClockOut" runat="server" Text="Clock Out" OnClick="btnClockOut_Click"/>
            <br />
            <br />
            <asp:Label ID="lblTimeClockStatus" runat="server" Font-Names="Monospace"></asp:Label>
        </div>
    </div>
 <%-- </form>--%>





</asp:Content>
