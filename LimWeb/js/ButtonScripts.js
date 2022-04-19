function SendRegPost()
{   
    try 
    {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "http://192.168.1.73:8080/registration", true);
        xhr.setRequestHeader('Content-Type', 'text/html');
        xhr.send('param1&param2&param3');
        xhr.onload = function() 
        {
            window.alert("Completed!", this.responseText);
        };
    }  
    catch(err) 
    {
        window.alert(`Error: ${err}`);
    }
}

/*
<script>
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function() {
  'use strict';

  window.addEventListener('load', function() {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName('needs-validation');

    // Loop over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function(form) {
      form.addEventListener('submit', function(event) {
        if (form.checkValidity() === false) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }, false);
})();
</script>
*/