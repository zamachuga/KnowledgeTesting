// Подготовка страницы.
function InstancePageTestManagement(CurrentContext) {
  MessageLoadContent("Content");
  GetAllQuestions(CurrentContext);
}

// Получить список всех квестов.
function GetAllQuestions(CurrentContext) {
  $.ajax({
    url: '/TestManagement/GetAllTests',
    type: 'GET',
    dataType: 'json',
    success: function (data) {
      CurrentContext.DataModels.AllTests = data;
    }
  });
}

function ShowAllTests(CurrentContext) {
  console.log(CurrentContext.DataModels.AllTests);
}