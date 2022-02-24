$(document).ready(function (){

    Ulkeler();
    Sehirler();
    Cinsiyet();

});

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
            var myDesign = "<option value = 0>Seçiniz</option>";

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
            var myDesign = "<option value = 0> Seçiniz.</option>";

            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].genderId + "'>" + myData[i].genderType + "</option>";
                console.log(myData[i].cityName);
            }
            $("#Cinsiyet").html(myDesign);


        }

    });
}

function Kaydet() {
    var EmployeeName = $("#name").val();
    var EmployeeSurname = $("#surname").val();
    var DateOfStartingJob = $("#date").val();
    var GenderId = $("#Cinsiyet").val();
    var CountryId = $("#Ulke option:selected").val();
    var CityId = $("#Sehir option:selected").val();
    var EmployeeAdress = $("#adress").val();

    var saveEmployee = {
        EmployeeName: EmployeeName,
        EmployeeSurname: EmployeeSurname,
        DateOfStartingJob: DateOfStartingJob,
        GenderId: GenderId,
        CountryId: CountryId,
        CityId: CityId,
        EmployeeAdress: EmployeeAdress

    }

    $.ajax({
        type: "Post",
        url: "/Employee/Kaydet/",
        dataType: "json",
        data: { e: saveEmployee },
        async: false,
        success: function () {

            window.location.href = "../../Employee";

        }

    });


 
}