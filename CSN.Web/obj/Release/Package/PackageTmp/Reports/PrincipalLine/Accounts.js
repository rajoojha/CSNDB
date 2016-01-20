/// <reference path="../Common/Common.js" />
/// <reference path="../Common/jquery-1.5.1.js" />

function ddlDistOnChange1(str) {
    var d = $(str);
    if (d.val() == "Retailer") {
        $("#h1").css('visibility', 'visible');
        $("#h2").css('visibility', 'visible');
        $("#h3").css('visibility', 'visible');
        $("#h4").css('visibility', 'visible');
        $("#h5").css('visibility', 'visible');
        $("#h2").attr('style', 'color: Black');
        $("#h6").css('visibility', 'visible');
    }
    else {
        $("#h1").css('visibility', 'hidden');
        $("#h2").css('visibility', 'hidden');
        $("#h3").css('visibility', 'hidden');
        $("#h4").css('visibility', 'hidden');
        $("#h5").css('visibility', 'hidden');
        $("#h6").css('visibility', 'hidden');
    }
}
$("#ddlAccountType1").bind("keydown change", function () {
    ddlDistOnChange(this);
});

function ddlDistOnChange(str) {
    var d = $(str);

    var vData = "pAccountType1=" + d.val();
    CJS_Global.CSNMethods.CallService("Accounts", "getAccount2", vData, function (pResult) {
        CJS_Global.CSNControls.DropDown.Bind("ddlAccountType2", pResult.Account2);

    });

    enabledisablecontrol(str);
}

function enabledisablecontrol(str) {
    var d = $(str);

    if (d.val() == "Retailer") {
        $("#trRet1").css('visibility', 'visible');
        $("#trRet2").css('visibility', 'visible');
        $("#trRet4").css('visibility', 'hidden');
        $("#trRet3").css('visibility', 'visible');
        $('.lblAcc').html("Number Of Stores");
    }
    else {
        $("#trRet1").css('visibility', 'hidden');
        $("#trRet2").css('visibility', 'hidden');
        $('.lblAcc').html("Number Of Accounts");
        $("#trRet3").css('visibility', 'hidden');
        $("#trRet4").css('visibility', 'visible');
    }
}

$(document).ready(function () {

    $('#ddlAccountType1').change(function () {
        ddlDistOnChange(this);
    });

    $('#ddlAccountType1').keypress(function () {
        ddlDistOnChange(this);
    });
    enabledisablecontrol('#ddlAccountType1');

});

window.onload = function () {

   
}
$(function () {
    FillJSTree2();
 
 
}); 
function Account_OnSearch() {
    this.Parameters = "&pCompanyName=" + encodeURIComponent($("#txtCompanyName").val()) +
                       "&pCSNDirID=" + encodeURIComponent($("#ddlCSNList").val()) +
                       "&pAccountType1=" + encodeURIComponent($("#ddlAccountType1").val()) +
                       "&pAccountType2=" + encodeURIComponent($("#ddlAccountType2").val()) +
                       "&pState=" + encodeURIComponent($("#ddlMState").val()) +
                       "&pDryOnly=" + encodeURIComponent($(".chkDryOnly").attr("checked") ? true : false) +
                       "&pFreezer=" + encodeURIComponent($(".chkFreezen").attr("checked") ? true : false) +
                       "&pFood=" + encodeURIComponent($(".chkFood").attr("checked") ? true : false) +
                       "&pZip=" + encodeURIComponent($("#txtMZip").val());
    this.OnSuccess = function (pResult) {
        $("#divAccountListData").html(pResult);
    }
    CJS_Global.CSNMethods.CallService("Accounts", "SearchAccounts", this.Parameters, this.OnSuccess);

}

function DeleteAccount(AccountCode, AccountName) {

    CJS_Global.CSNAlerts.Confirm("Do you really want to delete Account :" + AccountName + "", function () {
        this.Parameters = "AccountCode=" + encodeURIComponent(AccountCode);
        this.OnSuccess = function (pResult) {
            var vStatus = pResult.Status;
            var vAccountCode = pResult.AccountCode;
            if (vStatus == "S") {
                window.location.href = CJS_Global.SiteRoot + "/Accounts/ViewAccounts";
                CJS_Global.CSNAlerts.Successful("Account Deleted Sucessfully", function () {
                }
            );

            }
            else {

                CJS_Global.CSNAlerts.Alert("There is some error in this activity. Please try after some times.", "Error");

            }
        }
        CJS_Global.CSNMethods.CallService("Accounts", "DeleteAccount", this.Parameters, this.OnSuccess);
    });

}



function Account_OnUpdateValidate() {
    var arrValidateControls = new VJS_ValidatePageControls(Account_OnSave);
    arrValidateControls.Add("txtCompanyName", "Account Name", "TEXT", "ALL_M", 2000);
    arrValidateControls.Add("ddlCSNList", "CSN Ref", "SELECT", "ALL_M");

    arrValidateControls.Add("ddlAccountType1", "Account Type", "SELECT", "ALL_M");
    arrValidateControls.Add("txtCompanyPhone", "Company Phone", "TEXT", "ALL_M", 2000);

    arrValidateControls.Add("txtMAddress1", "Address1", "TEXT", "ALL_M", 2000);
    arrValidateControls.Add("txtMCity", "City", "TEXT", "ALL_M", 2000);
    arrValidateControls.Add("txtMZip", "Zip", "TEXT", "ALL_M", 2000);
    arrValidateControls.Add("ddlMState", "State", "SELECT", "ALL_M");
    arrValidateControls.Add("txtMCountry", "Country", "TEXT", "ALL_M", 2000);
    if (!arrValidateControls.DoValidate())
        return false;
}

function Account_OnSave() {
     
    var pArrayExempApprovalDetails = new Array();
    var pArrayDocumentDetails = new Array();
    var sStr = "";
    var counter_AR = 0;
    var counter_UD = 0;
    var obj = $(".jstree-checked");
    $.each(obj,
          function () {
              if ($(this).hasClass("jstree-leaf")) {
                  var vDivision = $(this).attr("id");
                  sStr = sStr + "#" + vDivision + ",";
                  counter_AR = counter_AR + 1;
              }
          }
        );
          sStr = sStr.substring(0, sStr.length - 1);
         
    this.Parameters = "&pAccountCode=" + encodeURIComponent($("#hdAccountCode").val()) +
                       "&pCompanyName=" + encodeURIComponent($("#txtCompanyName").val()) +
                       "&pCompanyPhone=" + encodeURIComponent($("#txtCompanyPhone").val()) +
                       "&pCompanyExt=" + encodeURIComponent($("#txtCompanyExt").val()) +
                       "&pCompanyFax=" + encodeURIComponent($("#txtCompanyFax").val()) +
                       "&pDryOnly=" + encodeURIComponent($(".chkDryOnly").attr("checked") ? true : false) +
                       "&pFreezer=" + encodeURIComponent($(".chkFreezen").attr("checked") ? true : false) +
                       "&pFood=" + encodeURIComponent($(".chkFood").attr("checked") ? true : false) +
                       "&pAccountType1=" + encodeURIComponent($("#ddlAccountType1").val()) +
                       "&pPrimaryAcctCode=" + encodeURIComponent($("#ddlPrimaryDistributor").val()) +
                       "&pNuberOfStores=" + encodeURIComponent($("#txtNuberOfStores").val()) +
                       "&pAccountType2=" + encodeURIComponent($("#ddlAccountType2").val()) +
                       "&pTerritory=" + encodeURIComponent(sStr) +
                       "&pDivision=" + encodeURIComponent($("#ddlDivision").val()) +
                       "&pCSNDirID=" + encodeURIComponent($("#ddlCSNList").val()) +
                       "&pAddress1=" + encodeURIComponent($("#txtMAddress1").val()) +
                       "&pAddress2=" + encodeURIComponent($("#txtMAddress2").val()) +
                       "&pCity=" + encodeURIComponent($("#txtMCity").val()) +
                       "&pState=" + encodeURIComponent($("#ddlMState").val()) +
                       "&pZip=" + encodeURIComponent($("#txtMZip").val()) +
                       "&pCountry=" + encodeURIComponent($("#txtMCountry").val()) +
                       "&pShipToName=" + encodeURIComponent($("#txtSName").val()) +
                       "&pShipToAddress1=" + encodeURIComponent($("#txtSAddress1").val()) +
                       "&pShipToAddress2=" + encodeURIComponent($("#txtSAddress2").val()) +
                       "&pShipToCity=" + encodeURIComponent($("#txtSCity").val()) +
                       "&pShipToState=" + encodeURIComponent($("#ddlSState").val()) +
                       "&pShipZip=" + encodeURIComponent($("#txtSZip").val()) +
                       "&pHotProgram=" + encodeURIComponent($(".chkHotProgram").attr("checked") ? true : false) +
                       "&pRollerGrid=" + encodeURIComponent($("#txtRollerGrid").val()) +
                       "&pGasBand=" + encodeURIComponent($("#txtGasBand").val()) +
                       "&pPrimaryDistributor=" + encodeURIComponent($("#ddlPrimaryDistributor").val()) +
                       "&pShipToCountry=" + encodeURIComponent($("#txtSCountry").val());

    if (encodeURIComponent($("#hdAccountCode").val()) == "undefined" || encodeURIComponent($("#hdAccountCode").val()) == "" || encodeURIComponent($("#hdAccountCode").val()) == null || encodeURIComponent($("#hdAccountCode").val()) == "-1") {
        this.OnSuccess = function (pResult) {
            var vStatus = pResult.Status;
            var vAccountCode = pResult.AccountCode;
            if (pResult.Status == "S") {
                CJS_Global.CSNAlerts.Successful(null, function () {
                    $("#hdAccountCode").val(vAccountCode);
                   
                    $(".accordion").accordion({ active: 1 });
                }
            );
            }
            else {

                CJS_Global.CSNAlerts.Alert("There is some error in this activity. Please try after some times.", "Error");

            }
        }

        CJS_Global.CSNMethods.CallService("Accounts", "SaveAccounts", this.Parameters, this.OnSuccess);
    }
    else {
        this.OnSuccess = function (pResult) {
            var vStatus = pResult.Status;
            var vAccountCode = pResult.AccountCode;
            if (pResult.Status == "S") {
                CJS_Global.CSNAlerts.Successful(null, function () {
                    $(".accordion").accordion({ active: 1 });
                  
                }
            );
            }
            else {

                CJS_Global.CSNAlerts.Alert("There is some error in this activity. Please try after some times.", "Error");

            }
        }

        CJS_Global.CSNMethods.CallService("Accounts", "SaveAccounts", this.Parameters, this.OnSuccess);
    }
} 

function Clear() {
    $("#hdAccountCode").val("");
    $("#txtCompanyName").val("");
    $("#txtCompanyPhone").val("");
    $("#txtCompanyExt").val("");
    $("#txtCompanyFax").val("");
    $('#chkDryOnly').attr("checked", false);
    $("#chkFreezen").attr("checked", false);
    $("#chkFood").attr("checked", false);
    $("#ddlAccountType1").val("--Select--");
    $("#ddlPrimaryDistributor").val("--Select--");
    $("#txtNuberOfStores").val("");
    $("#ddlAccountType2").val("--Select--"); 
    $("#ddlCSNList").val("--Select--"); 
    $("#txtMAddress1").val("");
    $("#txtMAddress2").val("");
    $("#txtMCity").val("");
    $("#ddlMState").val("--Select--");
    $("#txtMZip").val("");
    $("#txtMCountry").val("");
    $("#txtSName").val("");
    $("#txtSAddress1").val("");
    $("#txtSAddress2").val("");
    $("#txtSCity").val("");
    $("#ddlsState").val("--Select--");
    $("#txtSZip").val("");
    $("#txtSCountry").val("");
}
