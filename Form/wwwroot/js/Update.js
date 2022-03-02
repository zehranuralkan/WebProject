$(document).ready(function () {
    GetData();
    Ulkeler();
});


var id;
var query = (window.location).href;
id = query.substring(query.lastIndexOf('=') + 1);
var veriler = null;

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}


function GetData() {
    var id = getParameterByName("id");

    $.ajax({
        type: "Get",
        url: "/Employee/GetData/" + id,
        dataType:"json",
        data: { id: id },
        async: false,
        success: function (result) {
            
            $("#name").val(result.employeeName);
            $("#surname").val(result.employeeSurname);
            $("#date").val(result.dateOfStartingJob);
            $('#Cinsiyet option:contains("' + result.genderId + '")').attr('selected', 'selected');
            $("#adress").val(result.employeeAdress);
            $('#Ulke option:contains("' + result.countryId + '")').attr('selected', 'selected');
            Sehirler($('#Ulke option:contains("' + result.countryId + '")').val());
            $('#Sehir option:contains("' + result.cityName + '")').attr('selected', 'selected'); 
        }
    })
}

function updateKayit() {
    var EmployeeId = getParameterByName("id");
    var EmployeeName = $("#name").val();
    var EmployeeSurname = $("#surname").val();
    var DateOfStartingJob = $("#date").val();
    var GenderId = $("#Cinsiyet").val();
    var CountryId = $("#Ulke option:selected").val();
    var CityId = $("#Sehir option:selected").val();
    var EmployeeAdress = $("#adress").val();

    var update = {
        EmployeeId:EmployeeId,
        EmployeeName: EmployeeName,
        EmployeeSurname: EmployeeSurname,
        DateOfStartingJob: DateOfStartingJob,
        GenderId: GenderId,
        CountryId: CountryId,
        CityId: CityId,
        EmployeeAdress: EmployeeAdress,

    }
    $.ajax({
        type: "Post",
        url: "/Employee/UpdateKayit/",
        dataType: "json",
        data: { update: update },
        async: false,
        success: function () {

        } 
    });
    window.location.href = "/../Employee/Index";
  
}

function Ulkeler() {
    $.ajax({
        type: "Get",
        url: "/Employee/UlkeCekme",
        dataType: "json",
        async: false,
        success: function (result) {

            var myData = result;
            var myDesign = ""; 
            for (var i = 0; i < myData.length; i++) { 
                myDesign += "<option value='" + myData[i].tabloId + "'>" + myData[i].tanim + "</option>";
            }
            $("#Ulke").append(myDesign); 
        } 
    });

}

function Sehirler() {
    $.ajax({
        type: "Get",
        url: "/Employee/CityList/" + $("#Ulke").val(),
        dataType: "json",


        async: false,
        success: function (result) {
            var myData = result;
            var myDesign = "";

            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].tabloId + "'>" + myData[i].tanim + "</option>";
                console.log(myData[i].tabloId);
            }
            $("#Sehir").html(myDesign);


        }

    });
}


function Cinsiyet() {
    $.ajax({
        type: "Get",
        url: "/Employee/CinsiyetList",
        dataType: "json",


        async: false,
        success: function (result) {
            console.log(result);
            var myData = result;
            var myDesign = " ";

            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].genderId + "'>" + myData[i].genderType + "</option>";
                console.log(myData[i].cityName);
            }
            $("#Cinsiyet").html(myDesign);



        }

    });
}





