//this class contain methods related to nationality functionality
var Account = {
    //Member variables
    ActionName: null,
    SelectedXmlData: null,
    Longitude: null,
    Latitude: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

      Account.constructor();
        //Account.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

       Account.getLocation();
       // Account.myIP();
        $('#btnback').click(function () {

        });            
        $('.YourBackgroundClass').focus();
      
    },

    getLocation: function () {      
        if ($('#IsActive').val() == 'False') {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(Account.showPosition);
            } else {              
                Latitude.innerHTML = "Geolocation is not supported by this browser.";               
            }
        }
    },

    showPosition: function (position) {       
        Longitude.value = position.coords.longitude;
        Latitude.value = position.coords.latitude;
        IP.value = '192.168.10.1';    

    },

    myIP: function () {
        if (window.XMLHttpRequest) xmlhttp = new XMLHttpRequest();
        else xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.open("GET", " http://api.hostip.info/get_html.php ", false);
        xmlhttp.send();
        
        hostipInfo = xmlhttp.responseText.split("\n");
        var hostp = String(hostipInfo);
        var hostedIp = String(hostp).split(',');       
        var splitedhostedIp = hostedIp[2].split(':');
        var splitedIP = String(splitedhostedIp).split(',');        
        IP.value = "192.168.10.1";
        return false;
    }
};

