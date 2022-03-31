function check(input) {
    input.value = input.value.replace(/[^0-9]/g, ''); 
    input.value = input.value.replace(/(\..*)\./g, '$1');
    var valor = input.value;
    if (valor == ""){
        input.value = 0
    }
    try{
        valor = parseInt(input.value);
    }
    catch{
        valor = 0;
    }
    input.value = valor;
    var suma = parseInt(document.getElementById("numero1").value)+parseInt(document.getElementById("numero2").value);
    if (suma <= 0) {
        document.getElementById("sumar").disabled = true;
        document.getElementById("erromsg").innerHTML="El valor de la suma debe ser mayor a 0";
    } 
    else{
        document.getElementById("sumar").disabled = false;
        document.getElementById("erromsg").innerHTML="";
    }
  }

function calcular()
{
var num1 = document.getElementById("numero1").value;
var num2 = document.getElementById("numero2").value;
var suma = parseInt(num1) + parseInt(num2);
var data = {
"num1": num1, "num2": num2
}
console.log(suma);
$.ajax({
type: 'POST',
contentType: 'application/json',
url:'http://localhost:44358/api/Operation/',
data: JSON.stringify(data),
success: function(data){
$.each(data, function(index, item){
    if(index == "suma"){
        $('#resultado').html(item);
    }
    if(index == "estaEnFibo"){
        alert("Esta en serie Fibonacci: "+item);
    }
})
},
error: function( request, textStatus, errorThrown ){
console.log( errorThrown );
}
});
}