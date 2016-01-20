/// <reference path="../Common/Common.js" />
/// <reference path="../Common/jquery-1.5.1.js" />

$(function () {
    $('#ddlResultInit').change(function () {
        var dvalue = "";
        var value = $(this).val();
        if (value == 3) {
            dvalue = "" + $("#ddlBuyers option:selected").text() + " liked the product. " + $("#ddlBuyers option:selected").text() + " signed a D/A. I will process through " + $("#txCompany").val() + "";
        }
        else if (value == 4) {
            dvalue = "(" + $("#ddlBuyers option:selected").text() + ") is undecided about the item. I will follow up on my next visit to see (" + $("#ddlBuyers option:selected").text() + ")";
        }
        else if (value == 5) {
            dvalue = "(" + $("#ddlBuyers option:selected").text() + ") liked the product. (" + $("#ddlBuyers option:selected").text() + ") signed a D/A.  (" + $("#txCompany").val() + ") does not currently stock. I will continue to present to all of my customers and collect my D/A’s to present to (" + $("#txCompany").val() + ") for distribution once they bring the item in";
        }
        else if (value == 6) {
            dvalue = "(" + $("#ddlBuyers option:selected").text() + ") liked the product but would not sign a D/A. (" + $("#ddlBuyers option:selected").text() + ") will not force it into (" + $("#txCompany").val() + "). Once (" + $("#txCompany").val() + ") stocks the item I will represent to (" + $("#ddlBuyers option:selected").text() + ").";
        }
        else if (value == 7) {
            dvalue = "(" + $("#ddlBuyers option:selected").text() + ") has a conflicting agreement with competitor. No opportunity at this time. I will re-approach my next visit with (" + $("#ddlBuyers option:selected").text() + ") ";
        }
        else if (value == 8) {
            dvalue = "(" + $("#ddlBuyers option:selected").text() + ") did not like the product and does not think it will sell. I will re-approach my next visit with (" + $("#ddlBuyers option:selected").text() + ") ";
        }
        if (value == 3 || value == 4 || value == 5 || value == 6 || value == 7 || value == 8) {
            $("#txtComments").val(dvalue);
           
        }
    });
});
function InitiativeEntry_OnSearch() {
 
    this.Parameters = "&pCSNID=" + encodeURIComponent($("#ddlCSNList").val()) +
                    "&pMfgID=" + encodeURIComponent($("#ddlPrincipalList").val()) +
                     "&pResponseType=" + encodeURIComponent($("#ddlResponseType").val()) +
                     "&pInitResults=" + encodeURIComponent($("#ddlInitResults").val() );
                     

    this.OnSuccess = function (pResult) {
        $("#divGrlReviews").html(pResult);        
    }

    CJS_Global.CSNMethods.CallService("InitiativeEntry", "InitiativeEntry", this.Parameters, this.OnSuccess);
}

function InitiativeEntryPopup(InitiativeID, ContactID) {

  
    $('.hello').empty();
    var MyDiv = $("<div id='Initiative' isShowClose='N' title='Initiative Data Entry' width='950px' height='550px'>");
    var URL = "InitiativeEntry/InitiativeByID?InitiativeID=" + InitiativeID + "&ContactID=" + ContactID + "";

  
    CJS_Global.CSNMethods.LoadPage(MyDiv, URL, PreponedExemptedExemption_PageLoad, true, false, "InitiativeModalPopup");
}

function InitiativeDataEntryPopup(CSNID) {

    $('.hello').empty();
    $('#Initiative1').empty();
    var MyDiv = $("<div id='Initiative1' isShowClose='N' title='Initiative Data Entry' width='950px' height='550px'>");
    var URL = "InitiativeEntry/InitiativeByCSNID?CSNID=" + CSNID + ""; 
    CJS_Global.CSNMethods.LoadPage(MyDiv, URL, PreponedExemptedExemption_PageLoad, true, false, "InitiativeModalPopup");
}



function PreponedExemptedExemption_PageLoad() {


}
function ddListChange() {
   
}

function InitiativeDelete(InitiativeItemCode) {
 
    CJS_Global.CSNAlerts.Confirm("Do you really want to delete Initiative Entry Id :" + InitiativeItemCode + " #", function () {

        this.Parameters = "InitiativeItemCode=" + encodeURIComponent(InitiativeItemCode);

        this.OnSuccess = function (pResult) {

            var vStatus = pResult.Status;

            if (vStatus == "S") { 
                CJS_Global.CSNAlerts.Successful("Initiative Entry  Deleted Sucessfully", function () {
                    InitiativeEntry_OnSearch();
                }
            );

            }
            else {

                CJS_Global.CSNAlerts.Alert("There is some error in this activity. Please try after some times.", "Error");
                InitiativeEntry_OnSearch();

            }
        }
        CJS_Global.CSNMethods.CallService("InitiativeEntry", "InitiativeDelete", this.Parameters, this.OnSuccess);
    });

}

function ddlInitChange(pInit) {

  var d = $(pInit);
  var pInitiativeID = "pInitiativeID=" + d.val();
 
  CJS_Global.CSNMethods.CallService("InitiativeEntry", "getInitiativeBYID", pInitiativeID, function (pResult) { 
      $("#txtPrincipal").val(pResult.InitiativeList[0].MfgName);
      $("#txtInitiativeLabel").val(pResult.InitiativeList[0].InitiativeLabel);
      $("#txtInitiativeDesc").val(pResult.InitiativeList[0].InitiativeDesc);
      $("#hdInitiativeID").val(d.val());
  });
 }


function ddlBuyersChange(abc) {
    var d = $(abc); 
    var pAccountID = "pAccountID=" + d.val();
    CJS_Global.CSNMethods.CallService("InitiativeEntry", "getAccountBuyers", pAccountID, function (pResult) {
        CJS_Global.CSNControls.DropDown.Bind("ddlBuyers", pResult.BuyersList, "Select");
    });

    $("#txtPresentedTo").val("");
    $("#txtComments").val("");
    $("#ddlResultInit").val("");
}

$(document).ready(function () {

    $('#ddlAccount').change(function () {
        ddlBuyersChange(this);
       
       
    });

    $('#ddlBuyers').change(function () {
        $("#txtPresentedTo").val($("#ddlBuyers option:selected").text());
       
        $("#txtComments").val("");
        $("#ddlResultInit").val("");
    });


    $('#ddlInit').change(function () {
        ddlInitChange(this); 
    });
    
});

function vCheck(abc) {
    
    var ResultDetails = new Object();
    var $this = $(abc);
    // $this will contain a reference to the checkbox   
    if ($this.is(':checked')) {
        ResultDetails.pStatus = 1;
        $("#lblFollowup").text("Follow Up Date");
    } else {
       // ResultDetails.pStatus = 0;
        //  $("#lblFollowup").text("Appointment Date");
        ResultDetails.pStatus = 1;
        $("#lblFollowup").text("Follow Up Date");
    } 

    this.OnSuccess = function (pResult) {
        // CJS_Global.CSNControls.DropDown.Bind("ddlInitResults", pResult.InitResults, "Select");
        vBind("ddlResultInit", pResult.InitResults, "Select");
    }

    CJS_Global.CSNMethods.CallService("InitiativeEntry", "getResultType", ResultDetails, this.OnSuccess);

 
}

function InitiativeEntry_OnUpdateValidate() {
    var arrValidateControls = new VJS_ValidatePageControls(InitiativeEntry_OnSave);
    arrValidateControls.Add("ddlBuyers", "Buyers", "SELECT", "ALL_M");
    arrValidateControls.Add("ddlResultInit", "Init Results", "SELECT", "ALL_M");
    arrValidateControls.Add("txtInitiativeDesc", "InitiativeDesc", "TEXT", "ALL_M", 2000);
    
    if (!arrValidateControls.DoValidate())
        return false;
}
function InitiativeEntry_OnSave() {

    this.Parameters = "&pInitiativeItemCode=" + encodeURIComponent($("#hdpInitiativeItemCode").val()) +
                       "&pInitiativeID=" + encodeURIComponent($("#hdInitiativeID").val()) +
                       "&pAccountID=" + encodeURIComponent($("#ddlAccount").val()) +
                       "&pContactID=" + encodeURIComponent($("#ddlBuyers").val()) +
                       "&pPresented=" + encodeURIComponent($(".chkIsPresented").attr("checked") ? true : false) +
                       "&pPresentDate=" + encodeURIComponent($("#txtPresentationDate").val()) +
                       "&pPresentTo=" + encodeURIComponent($("#txtPresentedTo").val()) +
                       "&pInitResultID=" + encodeURIComponent($("#ddlResultInit ").val()) +
                       "&pFollowupDate=" + encodeURIComponent($("#txtfollowupDate").val()) +
                       "&pReasons=" + encodeURIComponent($("#txtComments").val()) +
                       "&pComments=" + encodeURIComponent($("#txtComments").val()) +
                       "&pEmailText=" + encodeURIComponent($("#txtInitiativeDesc").val());
  
    if (encodeURIComponent($("#hdpInitiativeItemCode").val()) == "" || encodeURIComponent($("#hdpInitiativeItemCode").val()) == null || encodeURIComponent($("#hdpInitiativeItemCode").val()) == "-1") {
        this.OnSuccess = function (pResult) {
            var vStatus = pResult.Status;
            var vInitiativeID = pResult.InitiativeID;
            var vContactID = pResult.ContactID;
            if (pResult.Status == "S") {
                CJS_Global.CSNAlerts.Successful(null, function () {
                    InitiativeEntry_OnSearch();
                    CJS_Global.CSNControls.ModalDialog.Close("InitiativeModalPopup");
                }
            );
            }
            else {

                CJS_Global.CSNAlerts.Alert("There is some error in this activity. Please try after some times.", "Error");

            }
        }

        CJS_Global.CSNMethods.CallService("InitiativeEntry", "SaveInitiativeEntry", this.Parameters, this.OnSuccess);
    }
    else {
        this.OnSuccess = function (pResult) {
            var vInitiativeID = pResult.InitiativeID;
            var vContactID = pResult.ContactID;
            if (pResult.Status == "S") {

                CJS_Global.CSNAlerts.Successful(null, function () {
                    InitiativeEntry_OnSearch();
                    CJS_Global.CSNControls.ModalDialog.Close("InitiativeModalPopup");
                }
            );



            }
            else {

                CJS_Global.CSNAlerts.Alert("There is some error in this activity. Please try after some times.", "Error");

            }
        } 
        CJS_Global.CSNMethods.CallService("InitiativeEntry", "SaveInitiativeEntry", this.Parameters, this.OnSuccess);
    }
}
function vBind(pControlID, pDataSource, pFirstOptionText, pSelectedValue) {
    var vControl; 
    if (typeof (pControlID) == 'string') {
        vControl = $("#" + pControlID);
    }
    else {
        vControl = pControlID;
    }

    vControl.html('');

    if (pFirstOptionText != undefined) {
        var vFirstOption = $("<option>");
        vFirstOption.attr("value", "");
        vFirstOption.html("--" + pFirstOptionText + "--");
        vControl.append(vFirstOption);
    }

    for (iCounter in pDataSource) {
      
        var vNewOption = $("<option>");
        vNewOption.attr("value", pDataSource[iCounter].Value);
        vNewOption.html(pDataSource[iCounter].Text);
        vControl.append(vNewOption);
       
    }

    if (pSelectedValue != 'undefined') {
        vControl.val(pSelectedValue);
    }
    vControl.Referes();
}