<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentAttendanceUserControl.ascx.cs" Inherits="SchoolManagementSystem.StudentAttendanceUserControl" %>


  <div style="background-image:url('../Image/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed;">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            
            <h3 class="text-center "><b>Students's Attendance Details</b></h3>

             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="ddlClass">Class</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Class is required" ForeColor="Red" ControlTovalidate="ddlClass" Display="Dynamic" 
                        SetFocusOnError="true" InitialValue="Select Class"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6">
                    <label for="ddlSubject">Subject</label>
                    <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
                <!--     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="Subject is required" ForeColor="Red" ControlTovalidate="ddlClass" Display="Dynamic" 
                        SetFocusOnError="true" placeholder="Select Subject" InitialValue="Select Subject"></asp:RequiredFieldValidator> -->
                </div>
            </div>

             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtRoll">Roll Number</label>
                    <asp:TextBox ID="txtRoll" runat="server" CssClass="form-control" placeholder="Enter Roll No." TextMode="Number"  required></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="txtMonth">Month</label>
                    <asp:TextBox ID="txtMonth" runat="server" CssClass="form-control" placeholder="Enter Monthr" TextMode="Month" required></asp:TextBox>
                </div>
            </div>



            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6 col-lg-4 col-xl-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Check Attendance" OnClick="btnSubmit_Click"/>
                     
                </div>
            </div>

            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-12">
                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!" AutoGenerateColumns="false">
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