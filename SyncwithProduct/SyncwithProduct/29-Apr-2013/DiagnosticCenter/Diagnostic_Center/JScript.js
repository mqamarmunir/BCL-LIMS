// JScript File
function CopyATA() 
{
  document.getElementById('txtATATime').value = document.getElementById('txtChocksOnTime').value;             
 } 
	
function CopyATD() 
{
  document.getElementById('txtATDTime').value = document.getElementById('txtChocksOffTime').value;             
 } 


function trsPCASE()
{
    strTemp = document.form1.txtString.value
    strTemp = strTemp.toLowerCase()

    var test=""
    var isFirstCharOfWord = 1

    for (var intCount = 0; intCount < strTemp.length; intCount++) 
    {

    var temp = strTemp.charAt(intCount)
    if (isFirstCharOfWord == 1)
    {
    temp = temp.toUpperCase()
    }

    test = test + temp
    if (temp == " ")
    {
    isFirstCharOfWord = 1
    }
    else isFirstCharOfWord = 0
    }
    document.form1.txtString.value = test
}
    function PCASE(s) 
    { 
        return s.replace(/(\w)(\w*)/g,function 
        ( 
            strMatch, 
            strFirst, 
            strRest, 
            intMatchPos, 
            strSource 
        ) 
        { 
            return strFirst.toUpperCase() 
            +strRest.toLowerCase(); 
        }); 
    } 
    
    function strTrim(str) {
var elem = document.getElementById(str).value;
document.getElementById(str).value = elem.replace(/^\s+|\s+$/g, '');
}

function strProperCase(str) {
var elem = document.getElementById(str).value;
document.getElementById(str).value = elem.toLowerCase().replace(/^(.)|\s(.)/g, 
function($1) { return $1.toUpperCase(); });
}
function TitleCase(objField) {
    alert('I am called');
            var objValues = objField.value.split(" ");
            var outText = "";
            for (var i = 0; i < objValues.length; i++) {
                outText = outText + objValues[i].substr(0, 1).toUpperCase() + objValues[i].substr(1).toLowerCase() + ((i < objValues.length - 1) ? " " : "");
            }
            return outText;
        }