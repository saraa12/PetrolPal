    var doughnutData = [
      {value:65,color:"#819596"},
      {value:100-65,color:"#dce0df"}
    ];
    
    // SMALL DOUGHNUT :(

    var smallDoughnutData = [
        {value:65,color:"#d9c54a"},
        {value:100-65,color:"#dce0df"}
      ];

    $( "#mySmallDoughnut" ).doughnutit({
      dnData: smallDoughnutData,
        dnSize: 130,
        dnInnerCutout: 60,
        dnAnimation: true,
      dnAnimationSteps: 60,
      dnAnimationEasing: 'linear',
      dnStroke: false,
      dnShowText: true,
      dnFontSize: '30px',
      dnFontOffset: 20,
      dnFontColor: "#819596",
      dnText: 'G1',
      dnStartAngle: 90,
      dnCounterClockwise: false,
      dnRightCanvas: {
        rcRadius: 5,
        rcPreMargin: 20,
        rcMargin: 20,
        rcHeight: 40,
        rcOffset: 5,
        rcLineWidth: 85,
        rcSphereColor: '#819596',
        rcSphereStroke: '#819596',        
        rcTop:{
          rcTopLineColor: '#819596',
          rcTopDashLine: 0,
          rcTopFontSize: '13px',
          rcStrokeWidth: 1,

          rcTopPreMargin: 20,
              rcTopMargin: 20,
              rcTopHeight: 40,
              rcTopLineWidth: 85,

          rctAbove: {           
            rctText: 'Average Cost',
            rctOffset: 2,
            rctImageOffsetRight: 5,
            rctImageOffsetBottom: 0,
            // rctImage: 'calendar.png',
          },
          rctBelow: {
            rctText: '6.5',
            rctFontSize: '35px',
            rctFontStyle: 'bold',
            rctOffset: 2,
            rctImageOffsetRight: 5,
            rctImageOffsetBottom: 0,
            // rctImage: 'calendar.png'
          }             
        },
        rcBottom:{          
          rcBottomDashLine: 0,
          rcBottomFontSize: '15px',
          rcBottomLineColor: '#819596',
          rcStrokeWidth: 1,

          rcBottomPreMargin: 20,
              rcBottomMargin: 20,
              rcBottomHeight: 30,
              rcBottomLineWidth: 85,

          rcbAbove: {
            // rcbImage: 'calendar.png',
            rcbImageOffsetBottom: 0,
            rcbImageOffsetRight: 5,
            rcbText: '7 DAYS',
            rcbFontSize: '13px',
            rcbOffset: 2
          },
          rcbBelow: {
            /*rcbImage: 'calendar.png',*/
            rcbImageOffsetRight: 5,
            rcbImageOffsetBottom: 0,
            rcbText: '20/10/2013',
            rcbOffset: 5
          }             
        }
      }
    });// End Doughnut