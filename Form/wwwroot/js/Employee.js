$(document).ready(function (){

    Ulkeler();
    Sehirler();
    Cinsiyet();
    Okul("Okul");

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

function Okul(x) {
    $.ajax({
        type: "Get",
        url: "/Employee/OkulGetir",
        dataType: "json",
        async: false,
        success: function (result) {
            console.log(result);
            var myData = result;
            var myDesign = "<option value = 0>Seçiniz.</option>";
            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].okulId + "'>" + myData[i].tanim + "</option>";
            }
            var nereyeBasilacak = "#" + x;
            $(nereyeBasilacak).html(myDesign);
        }
    })
}



var i = 0;
function OkulEkle() {
    i++;
 
    $('#okulTekrarliRow').append(`<br><div class="row" id='eklenenOkul${i}'">
                        <div class="col-md-3">
                        <label class="control-label">Okul Tipi</label>
                        <select id="Okul${i}" class="form-select okul">
                        <option value="0">Seçiniz</option>
                        </select> 
                        </div>
                        <div class="col-md-4">
                        <label class="control-label">Okul Adı</label> 
                        <input type="text" class="form-control" name="OkulAdi" id="OkulAdi${i}">
                        </div>
                        <div class="col-md-4">
                        <label class="control-label">Mezuniyet Tarihi</label> 
                        <input type="date" class="form-control" name="MezuniyetTarihi" id="MezuniyetTarihi${i}">
                        </div>
                        <div class="col-md-1">
                        <label class="control-label"> </label>
                        <button type="button" onclick="OkulSil(eklenenOkul${i})" style="height:35px;width:35px">-</button>
                        </div></div>`)
 
    var nereyeBassilacak = `Okul${i}`
    Okul(nereyeBassilacak);
   
};


function OkulSil(x) {
    
    $(x).remove();
    i--;

};


 function   Kaydet() {

    var PersonelEgitimler = [];
    var EmployeeName = $("#name").val();
    var EmployeeSurname = $("#surname").val();
    var DateOfStartingJob = $("#date").val();
    var GenderId = $("#Cinsiyet").val();
    var CountryId = $("#Ulke option:selected").val();
    var CityId = $("#Sehir option:selected").val();
    var EmployeeAdress = $("#adress").val();
    var MedyaId = $("#imgFile").attr("mediaId");

    var personelEgitimIlk = {};
     personelEgitimIlk["OkulId"] = $("#Okul").val(); ;
     personelEgitimIlk["OkulAdi"] = $("#OkulAdi").val(); ;
     personelEgitimIlk["MezuniyetTarihi"] = $("#MezuniyetTarihi").val(); 

     PersonelEgitimler.push(personelEgitimIlk);


     for (var x = 1; x <= i; x++) {
        var a = "#" + "Okul" + i + " option:selected";
        var OkulId = $(`${a}`).val();
        var b = "#" + "OkulAdi" + i;
        var OkulAdi = $(b).val(); 
        var MezuniyetTarihi = $(`#MezuniyetTarihi${x}`).val();
        var personelEgitim = {};
        personelEgitim["OkulId"] = OkulId;
        personelEgitim["OkulAdi"] = OkulAdi;
        personelEgitim["MezuniyetTarihi"] = MezuniyetTarihi;

        PersonelEgitimler.push(personelEgitim);


     }



    var saveEmployee = {
        EmployeeName: EmployeeName,
        EmployeeSurname: EmployeeSurname,
        DateOfStartingJob: DateOfStartingJob,
        GenderId: GenderId,
        CountryId: CountryId,
        CityId: CityId,
        EmployeeAdress: EmployeeAdress,
        PersonelEgitimler: PersonelEgitimler,
        MedyaId: MedyaId
    }


    $.ajax({
        type: "Post",
        url: "/Employee/Kaydet/",
        dataType: "json",
        data: { e: saveEmployee },
        async: false,
        success: function () {
        }

    });

     PersonelEgitimler = [];

}


function MedyaOlustur(id) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("a_" + id);
        preview.src = src;
        preview.style.display = "block";
    }
    console.log(id);
    var fdata = new FormData();
    var fileInput = $('#' + id)[0];
    var file = fileInput.files[0];
    fdata.append("iFormFile", file);


    $.ajax({
        type: "POST",
        url: "/Employee/MedyaOlustur/",
        data: fdata,
        contentType: false,
        processData: false,
        success: function (result) {
            console.log(result);
            if (result != 0) {
                $("#" + id).attr("mediaid", result);
                $("#medyaid").val(result);
            }
        }
    });
}



