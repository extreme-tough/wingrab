// JScript File

    function ShowPopupWindow(fileName) {
    
    
    window.location.reload
    
    myFloater = window.open('','myWindow','scrollbars=no,status=no,width=300,height=500')
    myFloater.location.href = fileName;
}

function ShowPopupWindowWithScrollbars(fileName) {
    myFloater = window.open('','myWindow','scrollbars=yes,resizable=yes,status=no,width=400,height=500')
    myFloater.location.href = fileName;
}

function ShowPopupWindowXY(fileName,x,y) {
    myFloater = window.open('','myWindow','scrollbars=no,status=no,width=' + x + ',height=' + y)
    myFloater.location.href = fileName;
}

function ShowPopupWindowXYWithScrollbars(fileName,x,y) {
    myFloater = window.open('','myWindow','scrollbars=yes,resizable=yes,status=no,width=' + x + ',height=' + y)
    myFloater.location.href = fileName;
}

function SizeToFit()
       {
        window.setTimeout(
            function()
            {
			if (document.body.scrollHeight > screen.height)
            {
				switch(screen.height)
				{
				case 600:
				window.resizeTo((document.body.scrollWidth + 20), 565);
				break;
				case 768:
				window.resizeTo((document.body.scrollWidth + 20), 733);
				break;
				default:
				window.resizeTo((document.body.scrollWidth + 20), (document.body.scrollHeight + 67));
				}
			} else
			{
			if (navigator.appVersion.indexOf('MSIE 7.0') > 0) {
			window.resizeTo((document.body.scrollWidth + 20), (document.body.scrollHeight + 87));
			}
			else {
			window.resizeTo((document.body.scrollWidth + 20), (document.body.scrollHeight + 67));
			}
			}
			}, 400);
       }

function ShowHtmlFieldPreviewLink_old(objField) {
		myFloater = window.open('','myWindow','scrollbars=yes,status=no,width=500,height=500')
		myFloater.location.href = '/RentACoder/misc/Isolate/PreviewHTMLField.asp?txtField=' + objField.value;
		}

function ShowHtmlFieldPreviewLink(objForm,objField) {

		strOldAction=objForm.action
		strOldTarget=objForm.target
		
		objForm.action='/RentACoder/misc/Isolate/PreviewHTMLField.asp?txtFieldName=' + objField.name;
		objForm.target='_blank';

		objForm.submit();

		objForm.action=strOldAction;
		objForm.target=strOldTarget;

		}

function myvoid() {	}


function disableForm(theform) 
	{
	if (document.all || document.getElementById) 
		{for (i = 0; i < theform.length; i++) 
			{var tempobj = theform.elements[i];
			if (tempobj.type.toLowerCase() == "submit" || tempobj.type.toLowerCase() == "reset")
				tempobj.disabled = true;
			}
			//setTimeout('alert("Your form has been submitted.  Notice how the submit and reset buttons were disabled upon submission.")', 2000);
			return true;
		}
	else {//alert("The form has been submitted.  But, since you're not using IE 4+ or NS 6, the submit button was not disabled on form submission.");
		return false;
		}

	}


	// -- toggle links //
	function toggle( targetId ){
	
  	if (document.getElementById){
  		target = document.getElementById( targetId );
  			if (target.style.display == "none"){
  				target.style.display = "";
  			} else {
  				target.style.display = "none";
  			}
  		}
	}
	function ShowDiv( targetId ){
  	if (document.getElementById){
  		target = document.getElementById( targetId );
		target.style.display = "";
  		}
	}
	function HideDiv( targetId ){
  	if (document.getElementById){
  		target = document.getElementById( targetId );
		target.style.display = "none";
  		}
	}



