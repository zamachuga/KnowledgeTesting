<script type="text/javascript">
    let _CurrentContext = {
        DataModels: {
        Dict: {
        Questions: null,
          Answers: {}
        }
      }
    };
    //select.options[select.selectedIndex].value

    $(document).ready(function () {
        PreparePageCreateTest(_CurrentContext);
    });

    // Подготовить страницу создания теста.
    function PreparePageCreateTest(CurrentContext) {
        $('#selectboxquestions').ready(function () {
            GetAllQuestions(CurrentContext);
            console.log(CurrentContext.DataModels.Questions[0]);
            ShowQuestionsFormCreateTest(CurrentContext.DataModels.Dict.Questions);
        });

      $("#btn_addquestion").click(function () {
        $.ajax({
            type: "POST",
            url: '/TestManagement/AddQuestion', //your action
            data: $('#createtestmodel').serialize(), //your form name.it takes all the values of model
            dataType: 'json',
            success: function (result) {
                //console.log(result);
            }
        }).done(function (res) {
            location.reload();
        });
        return false;
      });

      $("#btn_savetest").click(function () {
        $.ajax({
            type: "POST",
            url: '/TestManagement/SaveNewTest', //your action
            data: $('#createtestmodel').serialize(), //your form name.it takes all the values of model
            dataType: 'json',
            success: function (result) {
                //console.log(result);
            }
        }).done(function (res) {
            $('#createtestmodel').html(res);
        });
        return false;
      });
    }

    // Получить список всех квестов.
    function GetAllQuestions(CurrentContext) {
        $.ajax({
            url: '/TestManagement/GetQuestions',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                CurrentContext.DataModels.Dict.Questions = data;
            }
        });
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
  </script>