<%@ Page Title="" Language="C#" MasterPageFile="~/TimeClockMaster.Master" AutoEventWireup="true" CodeBehind="HoursWorked.aspx.cs" Inherits="MarshfieldTimeClock_V1._1.HoursWorked" %>
<%--Title--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Marshfield Hours Worked </title>
    <style type="text/css">
        /*#btn-hours{
            background-color: #1f3576;
        }*/
        .auto-style7 {
            /*width: 42px;*/
            border: thin solid #666666;
            height: 27px;
        }
        .auto-style8 {
            /*width: 65px;*/
            border: thin solid #666666;
            height: 27px;
        }
        .auto-style9 {
            /*width: 69px;*/
            border: thin solid #666666;
            height: 27px;
        }
    </style>
</asp:Content>
<%--Main--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div id="InteractivePage">
           <br />
           <h2 id="HoursWorkedHeader"> Hours Worked </h2>
           <br />
            <div id="Worked">
               <br />
                <asp:Table ID="HoursWorkedTable" runat="server" Height="96px" Width="218px" >
                     <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell></asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="wk1Header">Week 1</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="wk2Header">Week 2</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="wk3Header">Week 3</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="wk4Header">Week 4</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="wk5Header">Week 5</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="wk6Header">Week 6</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID ="TotalHeader">Total Hours</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow ID ="RowSunday" runat="server">
                        <asp:TableCell ID="Sunday">Sunday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Sun">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Sun">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Sun">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Sun">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Sun">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Sun">0</asp:TableCell>
                        <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowMonday" runat="server">
                        <asp:TableCell ID="Monday">Monday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Mon">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Mon">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Mon">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Mon">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Mon">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Mon">0</asp:TableCell>
                         <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowTuesday" runat="server">
                        <asp:TableCell ID="Tuesday">Tuesday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Tues">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Tues">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Tues">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Tues">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Tues">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Tues">0</asp:TableCell>
                         <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowWednessday" runat="server">
                        <asp:TableCell ID="Wednesday">Wednesday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Wed">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Wed">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Wed">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Wed">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Wed">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Wed">0</asp:TableCell>
                         <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowThursday" runat="server">
                        <asp:TableCell ID="Thursday">Thursday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Thur">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Thur">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Thur">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Thur">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Thur">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Thur">0</asp:TableCell>
                         <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowFriday" runat="server">
                        <asp:TableCell ID="Friday">Friday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Fri">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Fri">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Fri">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Fri">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Fri">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Fri">0</asp:TableCell>
                         <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowSaturday" runat="server">
                        <asp:TableCell ID="Saturday">Saturday</asp:TableCell>
                        <asp:TableCell ID ="Wk1Sat">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Sat">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Sat">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Sat">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Sat">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Sat">0</asp:TableCell>
                         <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow ID ="RowTotal" runat="server">
                        <asp:TableCell ID="Total">Total</asp:TableCell>
                        <asp:TableCell ID ="Wk1Total">0</asp:TableCell>
                        <asp:TableCell ID ="Wk2Total">0</asp:TableCell>
                        <asp:TableCell ID ="Wk3Total">0</asp:TableCell>
                        <asp:TableCell ID ="Wk4Total">0</asp:TableCell>
                        <asp:TableCell ID ="Wk5Total">0</asp:TableCell>
                        <asp:TableCell ID ="Wk6Total">0</asp:TableCell>
                        <asp:TableCell ID ="FinalTotal">0</asp:TableCell>
                    </asp:TableRow>
               </asp:Table>
               <br />
               <br />
           </div>
        </div>
    </form>
</asp:Content>

