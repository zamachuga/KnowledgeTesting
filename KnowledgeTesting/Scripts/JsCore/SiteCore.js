$.getScript("Scripts/JsCore/PageTestManagement.js", function () { });

let _CurrentContext = {
  DataModels: {
    AllTests: {}
  }
};

// После загрузки страницы.
$(document).ready(function () {
  ShowGeneralMenu();
  GeneralMenuFuctional(_CurrentContext);
});

// Подготовить страницу создания теста.
function GeneralMenuFuctional(CurrentContext) {
  $("#btn_GoTestManagement").click(function () {
    InstancePageTestManagement(CurrentContext);
  });

  $("#btn_GoTesting").click(function () {
    alert("btn_GoTestManagement");
  });

  $("#btn_GoStatistic").click(function () {
    alert("btn_GoStatistic");
  });

  //$('#selectboxquestions').ready(function () {
  //  GetAllQuestions(CurrentContext);
  //  console.log(CurrentContext.DataModels.Questions[0]);
  //  ShowQuestionsFormCreateTest(CurrentContext.DataModels.Dict.Questions);
  //});
  //$("#btn_addquestion").click(function () {
  //  $.ajax({
  //    type: "POST",
  //    url: '/TestManagement/AddQuestion', //your action
  //    data: $('#createtestmodel').serialize(), //your form name.it takes all the values of model
  //    dataType: 'json',
  //    success: function (result) {
  //      //console.log(result);
  //    }
  //  }).done(function (res) {
  //    location.reload();
  //  });
  //  return false;
  //});
  //$("#btn_savetest").click(function () {
  //  $.ajax({
  //    type: "POST",
  //    url: '/TestManagement/SaveNewTest', //your action
  //    data: $('#createtestmodel').serialize(), //your form name.it takes all the values of model
  //    dataType: 'json',
  //    success: function (result) {
  //      //console.log(result);
  //    }
  //  }).done(function (res) {
  //    $('#createtestmodel').html(res);
  //  });
  //  return false;
  //});
}

function ShowQuestionsFormCreateTest(Questions) {
  var _strResult = "";

  _strResult += '<select name="questions" id="questions">'
  $.each(Questions, function (index, Question) {
    _strResult += '<option value="' + Question.Id + '">' + Question.Text + '</option>';
  });
  _strResult += '</select>'

  $("#selectboxquestions").html(_strResult);
}

function ShowGeneralMenu() {
  $('#DivGeneralMenu').html(
    "<button id =\"btn_GoTestManagement\" class=\"btn btn-default\" > Редактирование теста</button>" +
    "<button id=\"btn_GoTesting\" class=\"btn btn-default\">Пройти тестирование</button>" +
    "<button id=\"btn_GoStatistic\" class=\"btn btn-default\">Статистика</button>"
  );
}

function ProgressLoadContent(DivId) {
  $('#' + DivId).html("Загрузка контента...");
}