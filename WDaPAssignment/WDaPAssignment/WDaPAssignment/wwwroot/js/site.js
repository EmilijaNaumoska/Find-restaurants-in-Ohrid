// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// JavaScript source code
function displayInfo(id) {
    if (document.getElementById(id) != null)
        document.getElementById(id).style.visibility = "visible";
}

function displayImage(url) {
    if (document.getElementById("imageDisplay") != null)
        document.getElementById("imageDisplay").innerHTML = "<img src='" + url + "'  class='img-responsive'/>"
}

function removeInfo(id) {
    if (document.getElementById(id) != null)
        document.getElementById(id).style.visibility = "hidden";
}
// Declare a variable for map   
var map;
// Get lattitude and longitude of Canberra Centre  
var canberraCentre = new google.maps.LatLng(-35.2792284, 149.1321033);
// Initialise the map   
function initMap() {
    // Define the properties for Canberra Centre map  
    var canberraMap = { center: canberraCentre, zoom: 13, mapTypeId: google.maps.MapTypeId.ROADMAP };
    // Create a map object for Canberra Centre     
    // using canberraMap and the <div> element with id="googleMap"   
    map = new google.maps.Map(document.getElementById("googleMap"), canberraMap);
    // Add markers below this line   
    BelluciItalian(map);
    ItalianAndSons(map);
    BluGinger(map);
    JewelOfIndia(map);
    ChairmanAndYip(map);
    DANHouse(map)
}

function BelluciItalian(map) {

    var restaurant = new google.maps.LatLng(-35.319631, 149.132443);
    var restaurantMarker = new google.maps.Marker({ position: restaurant, });
    restaurantMarker.setMap(map);
    var char = String.fromCharCode(45)
    var link = '<a href = "https://bellucis.com.au/home.php">Click Here</a>';
    var restaurantInfo = ' <h3>Belluci\'s Italian</h3>' +
        ' <img src="images/location/bellucis_logo.jpg"' +
        '      style="float:left; width:25%; margin-right:10px;">' +
        " <p>Belluci's demonstrates a new concept, a new food philosophy " + char + " the dawn of a new era in Canberra dining. " +
        "Having been established more than 20 years ago, Belluci's fast became an iconic name in Canberra. " +
        "To bring you the finest dishes, we\'ve gone back to traditional Italian routes, creating simple, rustic food.<br><br>"
        + link + " for the Belluci\'s Italian website.</p>";

    var popup = new google.maps.InfoWindow({ content: restaurantInfo });
    google.maps.event.addListener(restaurantMarker, 'click',
        function () {
            popup.open(map, restaurantMarker);
        });
}

function ItalianAndSons(map) {

    var restaurant = new google.maps.LatLng(-35.274983, 149.132327);
    var restaurantMarker = new google.maps.Marker({ position: restaurant, });
    restaurantMarker.setMap(map);
    var link = '<a href = "http://italianandsons.com.au/">Click Here</a>';
    var restaurantInfo = ' <h3>Italian and Sons</h3>' +
        ' <img src="images/location/is_logo.jpg"' +
        '      style="float:left; width:25%; margin-right:10px;">' +
        " <p>A casual Italian trattoria that specialises in wood fired pizzas such as Rucola with Prosciutto di Parma, " +
        "rucola & reggiano. Don't miss daily changing main dishes of the day such as their wood roast suckling pig," +
        "rosemary, garlic, baked baby fennel & mustard fruits.<br><br>"
        + link + " for the Italian and Sons website.</p>";

    var popup = new google.maps.InfoWindow({ content: restaurantInfo });
    google.maps.event.addListener(restaurantMarker, 'click',
        function () {
            popup.open(map, restaurantMarker);
        });
}

function BluGinger(map) {

    var restaurant = new google.maps.LatLng(-35.277031, 149.131981);
    var restaurantMarker = new google.maps.Marker({ position: restaurant, });
    restaurantMarker.setMap(map);
    var link = '<a href = "http://www.bluginger.com.au/">Click Here</a>';
    var restaurantInfo = ' <h3>Blu Ginger</h3>' +
        ' <img src="images/location/bluginger_logo.jpg"' +
        '      style="float:left; width:25%; margin-right:10px;">' +
        " <p>At Blu Ginger we use only the freshest locally sourced produce, combined with authentic " +
        "spices imported directly from the sub-continent, to offer classic, traditional recipes with " +
        "a modern twist, creating a unique and memorable dining experience for you.<br><br>"
        + link + " for the Blu Ginger website.</p>";

    var popup = new google.maps.InfoWindow({ content: restaurantInfo });
    google.maps.event.addListener(restaurantMarker, 'click',
        function () {
            popup.open(map, restaurantMarker);
        });
}

function JewelOfIndia(map) {

    var restaurant = new google.maps.LatLng(-35.320576, 149.132836);
    var restaurantMarker = new google.maps.Marker({ position: restaurant, });
    restaurantMarker.setMap(map);
    var link = '<a href = "http://www.jewelofindia.com.au/">Click Here</a>';
    var restaurantInfo = ' <h3>Jewel of India</h3>' +
        ' <img src="images/location/jewel_logo.jpg"' +
        '      style="float:left; width:25%; margin-right:10px;">' +
        " <p>Finding a balance between dishes inspired by authentic recipes and creating a modern take on " +
        "classic cuisine sees a loyal following of Canberra locals returning for a mouth-watering feast.<br><br>"
        + link + " for the Jewel of India website.</p>";

    var popup = new google.maps.InfoWindow({ content: restaurantInfo });
    google.maps.event.addListener(restaurantMarker, 'click',
        function () {
            popup.open(map, restaurantMarker);
        });
}

function ChairmanAndYip(map) {

    var restaurant = new google.maps.LatLng(-35.311668, 149.133955);
    var restaurantMarker = new google.maps.Marker({ position: restaurant, });
    restaurantMarker.setMap(map);
    var link = '<a href = "http://chairmangroup.com.au/chairmanyip/">Click Here</a>';
    var restaurantInfo = ' <h3>Chairman & Yip</h3>' +
        ' <img src="images/location/chairman_logo.jpg"' +
        '      style="float:left; width:25%; margin-right:10px;">' +
        " <p>The Chairman & Yip has become one of Canberra\'s longest standing and most highly regarded institutions, " +
        "having received numerous awards over the years, offering an ever consistent and professional quality " +
        "of service for corporate dining, conferences and presentations.<br><br>"
        + link + " for the Chairman & Yip website.</p>";

    var popup = new google.maps.InfoWindow({ content: restaurantInfo });
    google.maps.event.addListener(restaurantMarker, 'click',
        function () {
            popup.open(map, restaurantMarker);
        });
}

function DANHouse(map) {

    var restaurant = new google.maps.LatLng(-35.250328, 149.136434);
    var restaurantMarker = new google.maps.Marker({ position: restaurant, });
    restaurantMarker.setMap(map);
    var link = '<a href = "https://www.facebook.com/pages/Dickson-Asian-Noodle-House/156690017692038">Click Here</a>';
    var restaurantInfo = ' <h3>Dickson Asian Noodle House</h3>' +
        ' <img src="images/location/noodle_logo.jpg"' +
        '      style="float:left; width:25%; margin-right:10px;">' +
        " <p>The Dickson Asian Noodle House specialises in traditional Malaysian, Thai and Lao cuisine. " +
        "The dining atmosphere is casual and cosy providing for a la carte dining, banquets and take away.<br><br>"
        + link + " for the Dickson Asian Noodle House website.</p>";

    var popup = new google.maps.InfoWindow({ content: restaurantInfo });
    google.maps.event.addListener(restaurantMarker, 'click',
        function () {
            popup.open(map, restaurantMarker);
        });
}


google.maps.event.addDomListener(window, 'load', initMap);