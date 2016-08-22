
//Front Page Graph
d3.json('/Home/JsonGraphData/', function (data) {

    
    // returns max value from Data 
    // used to scale graph Y axis
    max = returnMaxFromArr(data)

    nv.addGraph(function () {
        //var chart = nv.models.lineChart()
        var chart = nv.models.multiBarChart()
            .x(function (d) {
                return d[0]
            })
            .y(function (d) {
                return d[1]
           })
          .useInteractiveGuideline(true)
          //.interpolate("monotone")
          //.isArea(true)
          .showLegend(true)
          .reduceXTicks(false)
        .showControls(false)
        ;
        
        chart.margin({ "left": 100})
        chart.forceY([1,(max*1.1)]);
        var monthNames = ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D'];
        chart.xAxis
            .tickValues([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])
            .tickFormat(function (d) {
                return monthNames[d - 1];
            });
        chart.yAxis
          .axisLabel('Revenue')
          .axisLabelDistance(40)
          .tickFormat(d3.format('$,f'))
        ;
        //data = mydata;
        d3.select('#chart svg')
          .datum(data)
          .transition().duration(500)
          .call(chart)
        ;
        nv.utils.windowResize(chart.update);
        return chart;
    });
});
//SaleManagers Graph
d3.json('/Graph/SaleManagerGraph/', function (data) {


    // returns max value from Data 
    // used to scale graph Y axis
    //max = returnMaxFromArr(data)

    nv.addGraph(function () {
        var chart = nv.models.lineChart()
        //var chart = nv.models.multiBarChart()
            .x(function (d) {
                return d[0]
            })
            .y(function (d) {
                return d[1]
            })
          .useInteractiveGuideline(true)
          .interpolate("monotone")
          .isArea(true)
          .showLegend(true)
        ;

        chart.margin({ "left": 100 })
        //chart.forceY([1, (max * 1.1)]);
        var monthNames = ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D'];
        chart.xAxis
            .tickValues([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])
            .tickFormat(function (d) {
                return monthNames[d - 1];
            });
        chart.yAxis
          .axisLabel('Revenue')
          .axisLabelDistance(40)
          .tickFormat(d3.format('$,f'))
        ;
        //data = mydata;
        d3.select('#ManagerChart svg')
          .datum(data)
          .transition().duration(500)
          .call(chart)
        ;
        nv.utils.windowResize(chart.update);
        return chart;
    });
});
//Dealer Graph
d3.json('/Graph/DealerGraph/', function (data) {


    // returns max value from Data 
    // used to scale graph Y axis
    //max = returnMaxFromArr(data)

    nv.addGraph(function () {
        var chart = nv.models.lineChart()
        //var chart = nv.models.multiBarChart()
            .x(function (d) {
                return d[0]
            })
            .y(function (d) {
                return d[1]
            })
          .useInteractiveGuideline(true)
          .interpolate("monotone")
          .isArea(true)
          .showLegend(true)
        ;

        chart.margin({ "left": 100 })
        //chart.forceY([1, (max * 1.1)]);
        var monthNames = ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D'];
        chart.xAxis
            .tickValues([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])
            .tickFormat(function (d) {
                return monthNames[d - 1];
            });
        chart.yAxis
          .axisLabel('Revenue')
          .axisLabelDistance(40)
          .tickFormat(d3.format('$,f'))
        ;
        //data = mydata;
        d3.select('#DealerChart svg')
          .datum(data)
          .transition().duration(500)
          .call(chart)
        ;
        nv.utils.windowResize(chart.update);
        return chart;
    });
});

// Method for getting max value in date for graph scaling
function returnMaxFromArr(data){
    var length = data[0].values.length;
    //var arr = data[0].values[11];

    var max = 0;
    for (i = 0; i < length; i++) {
        var arr = data[0].values[i];

        if (Math.max.apply(null, arr) > max) {
            max = Math.max.apply(null, arr);
        }
    }
    return max;
}


