// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function slowProgress(currentWeight, targetWeight, currentTdee) {

    let timeToTarget = 0;

    if (targetWeight > currentWeight) {
        timeToTarget = (targetWeight - currentWeight) * 3500 / 250;
        document.getElementById("progress").innerHTML = `At a slow pace, it will take you ${timeToTarget} days to reach your goal of ${targetWeight} pounds if you eat ${currentTdee + 250} calories per day`;
    } else {
        timeToTarget = (currentWeight - targetWeight) * 3500 / 250;
        document.getElementById("progress").innerHTML = `At a slow pace, it will take you ${timeToTarget} days to reach your goal of ${targetWeight} pounds if you eat ${currentTdee - 250} calories per day`;
    }


}
function moderateProgress(currentWeight, targetWeight, currentTdee) {
    let timeToTarget = 0;

    if (targetWeight > currentWeight) {
        timeToTarget = (targetWeight - currentWeight) * 3500 / 500;
        document.getElementById("progress").innerHTML = `At a moderate pace, it will take you ${timeToTarget} days to reach your goal of ${targetWeight} pounds if you eat ${currentTdee + 500} calories per day`;
    } else {
        timeToTarget = (currentWeight - targetWeight) * 3500 / 500;
        document.getElementById("progress").innerHTML = `At a moderate pace, it will take you ${timeToTarget} days to reach your goal of ${targetWeight} pounds if you eat ${currentTdee - 500} calories per day`;
    }


}
function fastProgress(currentWeight, targetWeight, currentTdee) {
    let timeToTarget = 0;

    if (targetWeight > currentWeight) {
        timeToTarget = (targetWeight - currentWeight) * 3500 / 1000;
        document.getElementById("progress").innerHTML = `At a fast pace, it will take you ${timeToTarget} days to reach your goal of ${targetWeight} pounds if you eat ${currentTdee + 1000} calories per day`;
    } else {
        timeToTarget = (currentWeight - targetWeight) * 3500 / 1000;
        document.getElementById("progress").innerHTML = `At a fast pace, it will take you ${timeToTarget} days to reach your goal of ${targetWeight} pounds if you eat ${currentTdee - 1000} calories per day`;
    }


}

function showMeAnExample(targetTdee, currentTdee) {
    let tdeeDif = Math.abs(targetTdee - currentTdee);
    
    let display = [];

    let calsArr = [200, 190, 140, 140, 390, 340, 150, 60, 70, 45, 47, 72, 80, 210];
    let foodsArr = ["servings of pasta", "Krispy Kreme glazed donuts", "pounds of spaghetti squash", "cans of Coca-Cola", "McDouble cheeseburgers", "slices of pepperoni pizza", "hot dogs", "chicken nuggets", "Oreos", "slices of bacon", "ounces of avocado",
        "hard-boiled eggs", "string cheese sticks", "cups of chocolate milk"];

    let randIndex = Math.floor(Math.random() * calsArr.length);
    let rounding = tdeeDif / calsArr[randIndex];
    display[0] = Math.round(rounding * 100) / 100;
    display[1] = foodsArr[randIndex];

    let p = document.getElementById("moreInfo");
    p.innerHTML = `The difference between your current and your target TDEE is approximately <b>${tdeeDif}</b> calories. This difference is approximately ${display[0]} ${display[1]}.`;
}























































/*function makeDateArray() {
    let dateArr = [
        { x: new Date(2014, 00, 01), y: 850 },
        { x: new Date(2014, 00, 08), y: 889 },
        { x: new Date(2014, 00, 15), y: 890 },
        { x: new Date(2014, 00, 22), y: 899 },
        { x: new Date(2014, 00, 29), y: 903 }
    ];
    return dataArr;
}

function slowProgress(currentWeight, targetWeight) {
    let weightArr = [];

    let i = 0;
    while (currentWeight > (targetWeight - .5)) {
        weightArr[i] = { y: currentWeight };
        currentWeight -= .5;
    }
    for (let i = 0; i === weightArr.length; i++) {
        weightArr[i] += { x: "Week " + (i + 1) };
    }
    return weightArr;
}

function moderateProgress(currentWeight, targetWeight) {
    let weightArr = [];

    let i = 0;
    while (currentWeight > (targetWeight - 1)) {
        weightArr[i] = { y: currentWeight };
        currentWeight -= 1;
    }
    for (let i = 0; i === weightArr.length; i++) {
        weightArr[i] += { x: "Week " + (i + 1) };
    }
    return weightArr;
}

function fastProgress(currentWeight, targetWeight) {
    let weightArr = [];

    let i = 0;
    while (currentWeight > (targetWeight - 2)) {
        weightArr[i] = { y: currentWeight };
        currentWeight -= 2;
    }
    for (let i = 0; i === weightArr.length; i++) {
        weightArr[i] += { x: "Week " + (i + 1) };
    }

    return weightArr;


    <script>
        window.onload = function () {

            let currentWeight = @Model.CurrentWeight;
            let targetWeight = @Model.TargetWeight;
            var chart = new CanvasJS.Chart("chartContainer", {
            title: {
            text: "House Median Price"
                },
                axisX: {
            valueFormatString: "Week"
                },
                axisY2: {
            title: "Time to Target Weight",
                    prefix: "",
                    suffix: " pounds"
                },
                toolTip: {
            shared: true
                },
                legend: {
            cursor: "pointer",
                    verticalAlign: "top",
                    horizontalAlign: "center",
                    dockInsidePlotArea: true,
                    itemclick: toogleDataSeries
                },
                data: [{
            type: "line",
                    axisYType: "secondary",
                    name: "Slow progress",
                    showInLegend: true,
                    markerSize: 0,
                    yValueFormatString: "### pounds",
                    dataPoints: slowProgress(currentWeight, targetWeight)
                },
                {
            type: "line",
                    axisYType: "secondary",
                    name: "Moderate progress",
                    showInLegend: true,
                    markerSize: 0,
                    yValueFormatString: "### pounds",
                    dataPoints: moderateProgress(currentWeight, targetWeight)
                },
                {
            type: "line",
                    axisYType: "secondary",
                    name: "Fast progress",
                    showInLegend: true,
                    markerSize: 0,
                    yValueFormatString: "### pounds",
                    dataPoints: fastProgress(currentWeight, targetWeight)
                }]
            });
            chart.render();

            function toogleDataSeries(e) {
                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
            e.dataSeries.visible = false;
                } else {
            e.dataSeries.visible = true;
                }
                chart.render();
            }

        }
</script>
        <div id="chartContainer" style="height: 370px; width: 100%;"></div>
        <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>*/
