'use strict';
$(function () {
    //Widgets count
    $('.count-to').countTo();

    //Sales count to
    $('.sales-count-to').countTo({
        formatter: function (value, options) {
            return '$' + value.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ' ').replace('.', ',');
        }
    });
    
    $('.assign-style').slimscroll({
		  height: '449px',
		  size: '5px'
		});
    $('#chat-conversation').slimscroll({
    	  height: '264px',
		  size: '5px'
		});
    $('.table-order').slimscroll({
		  height: '413px',
		  size: '5px'
		});

    initSparkline();
    initLineChart();
    initSalesChart();
});


function initSparkline() {
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });
}

function initLineChart() {
	 try {

		    //line chart
		    var ctx = document.getElementById("lineChart");
		    if (ctx) {
		      ctx.height = 150;
		      var myChart = new Chart(ctx, {
		        type: 'line',
		        data: {
		          labels: ["January", "February", "March", "April", "May", "June", "July"],
		          defaultFontFamily: "Poppins",
		          datasets: [
		            {
		              label: "My First dataset",
		              borderColor: "rgba(0,0,0,.09)",
		              borderWidth: "1",
		              backgroundColor: "rgba(0,0,0,.07)",
		              data: [22, 44, 67, 43, 76, 45, 12]
		            },
		            {
		              label: "My Second dataset",
		              borderColor: "rgba(0, 123, 255, 0.9)",
		              borderWidth: "1",
		              backgroundColor: "rgba(0, 123, 255, 0.5)",
		              pointHighlightStroke: "rgba(26,179,148,1)",
		              data: [16, 32, 18, 26, 42, 33, 44]
		            }
		          ]
		        },
		        options: {
		          legend: {
		            position: 'top',
		            labels: {
		              fontFamily: 'Poppins'
		            }

		          },
		          responsive: true,
		          tooltips: {
		            mode: 'index',
		            intersect: false
		          },
		          hover: {
		            mode: 'nearest',
		            intersect: true
		          },
		          scales: {
		            xAxes: [{
		              ticks: {
		                fontFamily: "Poppins"

		              }
		            }],
		            yAxes: [{
		              ticks: {
		                beginAtZero: true,
		                fontFamily: "Poppins"
		              }
		            }]
		          }

		        }
		      });
		    }


		  } catch (error) {
		    console.log(error);
		  }
}

function initSalesChart() {
	
	try {
	    //Sales chart
	    var ctx = document.getElementById("sales-chart");
	    if (ctx) {
	      ctx.height = 150;
	      var myChart = new Chart(ctx, {
	        type: 'line',
	        data: {
	          labels: ["2010", "2011", "2012", "2013", "2014", "2015", "2016"],
	          type: 'line',
	          defaultFontFamily: 'Poppins',
	          datasets: [{
	            label: "Foods",
	            data: [0, 30, 10, 120, 50, 63, 10],
	            backgroundColor: 'transparent',
	            borderColor: '#222222',
	            borderWidth: 2,
	            pointStyle: 'circle',
	            pointRadius: 3,
	            pointBorderColor: 'transparent',
	            pointBackgroundColor: '#222222',
	          }, {
	            label: "Electronics",
	            data: [0, 50, 40, 80, 40, 79, 120],
	            backgroundColor: 'transparent',
	            borderColor: '#f96332',
	            borderWidth: 2,
	            pointStyle: 'circle',
	            pointRadius: 3,
	            pointBorderColor: 'transparent',
	            pointBackgroundColor: '#f96332',
	          }]
	        },
	        options: {
	          responsive: true,
	          tooltips: {
	            mode: 'index',
	            titleFontSize: 12,
	            titleFontColor: '#000',
	            bodyFontColor: '#000',
	            backgroundColor: '#fff',
	            titleFontFamily: 'Poppins',
	            bodyFontFamily: 'Poppins',
	            cornerRadius: 3,
	            intersect: false,
	          },
	          legend: {
	            display: false,
	            labels: {
	              usePointStyle: true,
	              fontFamily: 'Poppins',
	            },
	          },
	          scales: {
	            xAxes: [{
	              display: true,
	              gridLines: {
	                display: false,
	                drawBorder: false
	              },
	              scaleLabel: {
	                display: false,
	                labelString: 'Month'
	              },
	              ticks: {
	                fontFamily: "Poppins"
	              }
	            }],
	            yAxes: [{
	              display: true,
	              gridLines: {
	                display: false,
	                drawBorder: false
	              },
	              scaleLabel: {
	                display: true,
	                labelString: 'Value',
	                fontFamily: "Poppins"

	              },
	              ticks: {
	                fontFamily: "Poppins"
	              }
	            }]
	          },
	          title: {
	            display: false,
	            text: 'Normal Legend'
	          }
	        }
	      });
	    }


	  } catch (error) {
	    console.log(error);
	  }
}