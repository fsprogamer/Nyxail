﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TestWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script src="scripts/jquery-1.4.1.js" type="text/javascript"></script>	
    <script  type="text/javascript">
        $(document).ready(function () {
           jQuery(".FormContent").submit(function (e) {
               e.preventDefault();
               var formData = [];
               formData[0] = $("#name").val();
               formData[1] = $("#color").val();
               formData[2] = $("#18-years").is(':checked');
               formData[3] = $("input:radio:checked").val();
                  
               var jsonData = JSON.stringify({ formData: formData });

               $.ajax({
                   type: "POST",
                   url: "Default.aspx/getformData",
                   data: jsonData,
                   contentType: "application/json; charset=utf-8",
                   dataType: "json", 
                   async: true,
                   cache: false,
                   success: OnSuccess,
                   error: OnErrorCall
               });
           });
       });
        
        function OnErrorCall(jqXHR, textStatus, exception) {
                $("#dialog").empty();
                var msg = '';
                var r = jQuery.parseJSON(jqXHR.responseText);
                msg = r.Message;
               
                //alert("Error: " + msg);
                $("#dialog").append(msg);
        }

        function OnSuccess(response) {
            $("#dialog").empty();
            var item = response.d;      
            var msg = '';
            var Name = item.Name;
            var FavoriteColor = item.FavoriteColor;
            var Over18 = item.Over18;
            var FavoriteTime = item.FavoriteTime;
            msg += Name + " - " + FavoriteColor + " - " + Over18 + " - " + FavoriteTime + "<br>";

            //alert("Success: " + msg);
            $("#dialog").append(msg);
       }
    </script>

    <h2>Test form</h2>
	<form action="Default.aspx">
		<table>
			<tr>
				<td><label for="name">Your name:</label></td>
				<td><input type="text" id="name"/>   
				</td>
			</tr>
			<tr>
				<td><label for="color">Your favourite color:</label></td>
				<td>
					<select id="color">
						<option>Green</option>
						<option>Red</option>
						<option>Yellow</option>
					</select>
				</td>
			</tr>
			<tr>
				<td><label for="18-years">You are older than 18 years</label></td>
				<td><input type="checkbox" id="18-years"/>
				</td>
			</tr>
			<tr>
				<td>Your favourite time of day:</td>
				<td>
					<input type="radio" id="radio-morning" value ="Morning" name="TimeOfDay"/><label for="radio-morning">Morning</label><br />
					<input type="radio" id="radio-evening" value ="Evening" name="TimeOfDay"/><label for="radio-evening">Evening</label><br />
					<input type="radio" id="radio-night" value ="Night" name="TimeOfDay"/><label for="radio-night">Night</label><br />
				</td>
			</tr>
			<tr>
				<td colspan="2"><input type="submit" /></td>
			</tr>
		</table>
		<div id="dialog">
        </div>
	</form>
</asp:Content>
