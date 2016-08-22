/* ============================================================
 * Dashboard
 * Generates widgets in the dashboard
 * For DEMO purposes only. Extract what you need.
 * ============================================================ */
(function($) {

    'use strict';

    $(document).ready(function() {
        //Get from JSON data and build

    
        // Widget 13
        $('.widget-13-map').mapplic({
            source: 'http://revox.io/json/dashboard-map.json',
            height: 465,
            sidebar: false,
            minimap: false,
            locations: true,
            deeplinking: true,
            fullscreen: false,
            developer: false,
            maxscale: 3
        });

        // Disable scroll to zoom
        setTimeout(function() {
            //location.hash = "#usa";
            $('.mapplic-layer').unbind('mousewheel DOMMouseScroll');
        }, 1000);


        $('.widget-13 a[data-toggle="tab"]').on('show.bs.tab', function(e) {
            var target = $(e.target).text().trim();
            var hash;
            if (target == 'fb') {
                hash = '#usa';
            } else if (target == 'sa') {
                hash = '#af';
            } else if (target == 'js') {
                hash = '#ru';
            }
            //window.location.hash = hash;
        });

        // tiles
        $(".widget-3 .metro").liveTile();
        $(".widget-7 .metro").liveTile();


        //NVD3 Charts
        //d3.json('/Home/GetSalesHistory', function (data) {
            
            // line chart
            (function() {
                nv.addGraph(function() {
                    //var chart = nv.models.lineChart()
                    var chart = nv.models.multiBarChart()
                        .x(function(d) {
                            return d[0]
                        })
                        .y(function(d) {
                            return d[1]
                        })
                        .color(["#18b9b1", "#f55753"])
                        .showLegend(false)
                        .margin({
                            left: 90,
                            bottom: 70
                        })
                        .useInteractiveGuideline(true);

                    //var monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec'];
                    var monthNames = ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D'];
                    chart.xAxis
                        .tickValues([1,2,3,4,5,6,7,8,9,10,11,12])
                        .tickFormat(function (d) {
                            return monthNames[d-1];
                            //return d3.time.format('%b')(new Date(d))
                        });
                    chart.reduceXTicks(false).showControls(false)
                    
                    chart.yAxis.tickFormat(d3.format(',.0f'));


                    d3.select('.nvd3-line svg')
                        .datum(data)
                        .transition().duration(500)
                        .call(chart);

                    nv.utils.windowResize(chart.update);

                    $('.nvd3-line').data('chart', chart);

                    return chart;
                });
          //  })();


            // line chart2
            //(function() {
            //    nv.addGraph(function() {
            //        var chart = nv.models.lineChart()
            //            .interpolate("basis")
            //            .x(function(d) {
            //                return d[0]
            //            })
            //            .y(function(d) {
            //                return d[1] / 100
            //            })
            //            .color([
            //                $.Pages.getColor('success')
            //            ])
            //            .useInteractiveGuideline(true)

            //        .margin({
            //                top: 150,
            //                right: -10,
            //                bottom: -10,
            //                left: -10
            //            })
            //            .showXAxis(false)
            //            .showYAxis(false)
            //            .showLegend(false);


            //        d3.select('.widget-2-chart svg')
            //            .datum(data.nvd3.interpolated)
            //            .transition().duration(500)
            //            .call(chart);


            //        nv.utils.windowResize(chart.update);

            //        $('.widget-2-chart').data('chart', chart);

            //        return chart;
            //    }, function() {

            //    });
            //})();

            //// line chart2
            //(function() {
            //    nv.addGraph(function() {
            //        var chart = nv.models.lineChart()
            //            .x(function(d) {
            //                return d[0]
            //            })
            //            .y(function(d) {
            //                return d[1] / 100
            //            })
            //            .color([
            //                $.Pages.getColor('success')
            //            ])
            //            .forceY([0, 2])
            //            .useInteractiveGuideline(true)

            //        .margin({
            //                top: 60,
            //                right: -10,
            //                bottom: -10,
            //                left: -10
            //            })
            //            .showLegend(false);


            //        d3.select('.widget-4-chart svg')
            //            .datum(data.nvd3.productRevenue)
            //            .transition().duration(500)
            //            .call(chart);


            //        nv.utils.windowResize(function() {
            //            //chart.update();
            //        });

            //        $('.widget-4-chart').data('chart', chart);

            //        return chart;
            //    }, function() {

            //    });
            //})();

            // Widget 15

            //(function() {
            //    var container = '#widget-15-chart';

            //    var seriesData = [
            //        [],
            //        []
            //    ];
            //    var random = new Rickshaw.Fixtures.RandomData(40);
            //    for (var i = 0; i < 40; i++) {
            //        random.addData(seriesData);
            //    }

            //    var graph = new Rickshaw.Graph({
            //        renderer: 'bar',
            //        element: document.getElementById(container),
            //        height: 200,
            //        padding: {
            //            top: 0.5
            //        },
            //        series: [{
            //            data: seriesData[0],
            //            color: $.Pages.getColor('complete-light'),
            //            name: "New users"
            //        }, {
            //            data: seriesData[1],
            //            color: $.Pages.getColor('master-lighter'),
            //            name: "Returning users"

            //        }]

            //    });

            //    var hoverDetail = new Rickshaw.Graph.HoverDetail({
            //        graph: graph,
            //        formatter: function(series, x, y) {
            //            var date = '<span class="date">' + new Date(x * 1000).toUTCString() + '</span>';
            //            var swatch = '<span class="detail_swatch" style="background-color: ' + series.color + '"></span>';
            //            var content = swatch + series.name + ": " + parseInt(y) + '<br>' + date;
            //            return content;
            //        }
            //    });

            //    graph.render();

            //    $(window).resize(function() {
            //        graph.configure({
            //            width: $(container).width(),
            //            height: 200
            //        });

            //        graph.render()
            //    });

            //    $(container).data('chart', graph);

            //})();


            // widget 15-2
            //(function() {
            //    var container = '.widget-15-chart2';

            //    var seriesData = [
            //        [],
            //        []
            //    ];
            //    var random = new Rickshaw.Fixtures.RandomData(40);
            //    for (var i = 0; i < 40; i++) {
            //        random.addData(seriesData);
            //    }

            //    var graph = new Rickshaw.Graph({
            //        renderer: 'bar',
            //        element: document.querySelector(container),
            //        padding: {
            //            top: 0.5
            //        },
            //        series: [{
            //            data: seriesData[0],
            //            color: $.Pages.getColor('complete-light'),
            //            name: "New users"
            //        }, {
            //            data: seriesData[1],
            //            color: $.Pages.getColor('master-lighter'),
            //            name: "Returning users"

            //        }]

            //    });

            //    var hoverDetail = new Rickshaw.Graph.HoverDetail({
            //        graph: graph,
            //        formatter: function(series, x, y) {
            //            var date = '<span class="date">' + new Date(x * 1000).toUTCString() + '</span>';
            //            var swatch = '<span class="detail_swatch" style="background-color: ' + series.color + '"></span>';
            //            var content = swatch + series.name + ": " + parseInt(y) + '<br>' + date;
            //            return content;
            //        }
            //    });

            //    graph.render();

            //    $(window).resize(function() {
            //        graph.configure({
            //            width: $(container).width(),
            //            height: 200
            //        });

            //        graph.render()
            //    });

            //    $(container).data('chart', graph);

            //})();


            // widget 5
        //    (function() {
        //        var container = '.widget-5-chart';

        //        var seriesData = [
        //            [],
        //            []
        //        ];
        //        var random = new Rickshaw.Fixtures.RandomData(7);
        //        for (var i = 0; i < 7; i++) {
        //            random.addData(seriesData);
        //        }

        //        var graph = new Rickshaw.Graph({
        //            element: document.querySelector(container),
        //            renderer: 'bar',
        //            series: [{
        //                data: [{
        //                    x: 0,
        //                    y: 10
        //                }, {
        //                    x: 1,
        //                    y: 8
        //                }, {
        //                    x: 2,
        //                    y: 5
        //                }, {
        //                    x: 3,
        //                    y: 9
        //                }, {
        //                    x: 4,
        //                    y: 5
        //                }, {
        //                    x: 5,
        //                    y: 8
        //                }, {
        //                    x: 6,
        //                    y: 10
        //                }],
        //                color: $.Pages.getColor('danger')
        //            }, {
        //                data: [{
        //                    x: 0,
        //                    y: 0
        //                }, {
        //                    x: 1,
        //                    y: 2
        //                }, {
        //                    x: 2,
        //                    y: 5
        //                }, {
        //                    x: 3,
        //                    y: 1
        //                }, {
        //                    x: 4,
        //                    y: 5
        //                }, {
        //                    x: 5,
        //                    y: 2
        //                }, {
        //                    x: 6,
        //                    y: 0
        //                }],
        //                color: $.Pages.getColor('master-light')
        //            }]

        //        });


        //        var MonthBarsRenderer = Rickshaw.Class.create(Rickshaw.Graph.Renderer.Bar, {
        //            barWidth: function(series) {

        //                return 7;
        //            }
        //        });


        //        graph.setRenderer(MonthBarsRenderer);


        //        graph.render();


        //        $(window).resize(function() {
        //            graph.configure({
        //                width: $(container).width(),
        //                height: $(container).height()
        //            });

        //            graph.render()
        //        });

        //        $(container).data('chart', graph);

        //    })();

        });


        // Init portlets

        var bars = $('.widget-loader-bar');
        var circles = $('.widget-loader-circle');
        var circlesLg = $('.widget-loader-circle-lg');
        var circlesLgMaster = $('.widget-loader-circle-lg-master');



        bars.each(function() {
            var elem = $(this);
            elem.portlet({
                progress: 'bar',
                onRefresh: function() {
                    setTimeout(function() {
                        elem.portlet({
                            refresh: false
                        });
                    }.bind(this), 2000);
                }
            });
        });


        circles.each(function() {
            var elem = $(this);
            elem.portlet({
                progress: 'circle',
                onRefresh: function() {
                    setTimeout(function() {
                        elem.portlet({
                            refresh: false
                        });
                    }.bind(this), 2000);
                }
            });
        });

        circlesLg.each(function() {
            var elem = $(this);
            elem.portlet({
                progress: 'circle-lg',
                progressColor: 'white',
                overlayColor: '0,0,0',
                overlayOpacity: 0.6,
                onRefresh: function() {
                    setTimeout(function() {
                        elem.portlet({
                            refresh: false
                        });
                    }.bind(this), 2000);
                }
            });
        });


        circlesLgMaster.each(function() {
            var elem = $(this);
            elem.portlet({
                progress: 'circle-lg',
                progressColor: 'master',
                overlayOpacity: 0.6,
                onRefresh: function() {
                    setTimeout(function() {
                        elem.portlet({
                            refresh: false
                        });
                    }.bind(this), 2000);
                }
            });
        });

    });

})(window.jQuery);