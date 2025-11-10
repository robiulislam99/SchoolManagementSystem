<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="EmpAttendanceDetails.aspx.cs" Inherits="SchoolManagementSystem.Admin.EmpAttendanceDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image:url('../Image/bg.jpg'); width:100%; height:100%; background-repeat:no-repeat; background-size:cover; background-attachment:fixed;">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center "><b>Teacher's Attendance Details</b> </h3>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">

                <div class="col-md-6">
                    <label for="ddlTeacher">Teacher</label>
                    <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="form-control" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Teacher is required" 
                        ControlToValidate="ddlTeacher" Display="Dynamic" ForeColor="Red" InitialValue="Select Teacher" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6">
                    <label for="txtMonth">Month</label>
                    <asp:TextBox ID="txtMonth" runat="server" CssClass="form-control" placeholder="Enter Monthr" TextMode="Month" required></asp:TextBox>
                </div>
            </div>


            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Check Attendance" OnClick="btnAdd_Click"/>
                     
                </div>
            </div>

            
           <div class="row mb-3 mr-lg-5 ml-lg-5">
    <div class="col-md-6">
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!"
            AllowPaging="True" PageSize="4" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Name">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="status" HeaderText="Status">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd MMMM yyyy}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
             <HeaderStyle BackColor="#5558C9" ForeColor="White" />
        </asp:GridView>
    </div>
</div>


        </div>
    </div>

</asp:Content>
