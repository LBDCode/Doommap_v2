
import L from 'leaflet';

export default {
    calcFireMetrics: function (fireData) {

        let dailyAcres = 0;
        let numberFires;
        let largestFire;

        let filteredFireData = fireData.filter(fire => {
            if (fire['dailyacres'] > 100) {
                dailyAcres += fire['dailyacres']
                return fire
                }
            }
        )

        numberFires = filteredFireData.length
        largestFire = filteredFireData.reduce((max, fire) => max['dailyacres'] > fire['dailyacres']  ? max : fire);

        return ({ 'numberFires': numberFires, 'dailyAcres': dailyAcres, 'largestFire': largestFire })
    },
    calcFloodMetrics: function (areaData) {
        let numberFloodWarnings = areaData.length;

        return ({ 'numberFloodWarnings': numberFloodWarnings})

    },
    calcRedFlagMetrics: function (areaData) {
        let numberRedFlagAdvisories = areaData.length;

        console.log(areaData)

    }

};