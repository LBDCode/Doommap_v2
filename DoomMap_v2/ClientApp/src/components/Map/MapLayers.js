import React, { Component, useEffect, useContext } from 'react';
import { MapContainer, TileLayer, Marker, CircleMarker, LayersControl, Popup, Tooltip, Polygon, Polyline, FeatureGroup, LayerGroup, GeoJSON } from 'react-leaflet';
import L from 'leaflet';
import AppContextProvider, { AppContext } from '../../context/AppContext';


let DefaultIcon = L.icon({
    iconUrl: require('./fire.png'),
    iconRetinaUrl: require('./fire.png'),
    iconAnchor: new L.Point(0, 0),
    popupAnchor: new L.Point(16, 0),
    shadowUrl: null,
    shadowSize: null,
    shadowAnchor: null,
    iconSize: new L.Point(60, 75),
    className: 'firePoint'
});



export default function Map(props) {

    const { updateDisasterMetrics, allFires, allDroughts, allAreas } = useContext(AppContext);

    const returnStormTrackCoordinates = (geoJSONcoords) => {

        let mappedCoords = geoJSONcoords.map(coord => {
            const newCoord = [coord[1], coord[0]]
            return newCoord
        });

        return mappedCoords;
    }


    const yellowOptions = { fillColor: 'yellow', stroke: false }
    const orangeOptions = { fillColor: 'orange', stroke: false }
    const redOptions = { fillColor: 'red', stroke: false }
    const greenOptions = { fillColor: 'green', stroke: false }
    const blueOptions = { fillColor: 'blue', stroke: false }
    const purpleOptions = { fillColor: 'purple', stroke: false }
    const blackOptions = { color: 'black', weight: '2' }



    useEffect(() => {
        if (allFires) {
            console.log(allFires)

        }
    }, [allFires])


    return (
        <LayersControl position="topright">
            <LayersControl.Overlay checked name="Active Fires">
                <FeatureGroup>
                    {
                        allFires ? allFires.map(fire => {

                            if (fire && fire['geom']) {

                                const point = [fire['geom']['coordinates'][1], fire['geom']['coordinates'][0]]

                                return (
                                    <Marker icon={DefaultIcon} key={fire['objectid']} position={point}>
                                        <Tooltip sticky>
                                            <span>Fire: {fire['incidentname'] ? fire['incidentname'] : 'N/A'}</span>
                                            <br />
                                            <span>Daily acres burned: {fire['dailyacres'] ? fire['dailyacres'] : 'N/A'} acres</span>
                                            <br />
                                            <span>Reported date: {fire['firediscoverydatetime'] ? fire['firediscoverydatetime'] : 'N/A'}</span>
                                            <br />
                                            <span>Description: {fire['incidentshortdescription'] ? fire['incidentshortdescription'] : 'N/A'}</span>
                                            <br />
                                        </Tooltip>
                                    </Marker>
                                )
                            }
                        })
                            : null
                    }

                </FeatureGroup>
            </LayersControl.Overlay>
            <LayersControl.Overlay checked name="Drought Conditions">

                <FeatureGroup>
                    {allDroughts ?
                        allDroughts.map(area => {

                            function returnColor(dmScore) {

                                let color;

                                if (dmScore === 2) {
                                    color = yellowOptions;
                                } else if (dmScore === 3) {
                                    color = orangeOptions;
                                } else if (dmScore === 4) {
                                    color = redOptions;
                                }
                                return color;
                            }

                            const dmData = {
                                2: "Severe Drought",
                                3: "Extreme Drought",
                                4: "Exceptional Drought"
                            }


                            if (area && area['geom'] && area.dm && area.dm >= 2) {
                                return (
                                    <GeoJSON pathOptions={returnColor(area.dm)} key={area['gid']} data={area['geom']}>
                                        <Tooltip sticky>
                                            <span>Drought Warning</span>
                                            <br />
                                            <span>Severity: D{area['dm']} ({dmData[area['dm']]})</span>
                                            <br />
                                        </Tooltip>
                                    </GeoJSON>
                                )
                            }

                        })
                        : null
                    }

                </FeatureGroup>
            </LayersControl.Overlay>
            <LayersControl.Overlay checked name="Fire Warnings/Red Flag Areas">
                <FeatureGroup>
                    {
                        allAreas ? allAreas.map(area => {

                            if (area && area['geom'] && area.prodType == 'Fire Weather Watch') {
                                return (
                                    < GeoJSON pathOptions={redOptions} key={area['gid']} data={area['geom']}>
                                        <Tooltip sticky>
                                            <span>{area['prodType']}</span>
                                            <br />
                                            <span>In Effect: {area['onset']} - {area['ends']}</span>
                                            <br />
                                        </Tooltip>
                                    </GeoJSON>
                                )
                            }

                        })
                            : null
                    }
                </FeatureGroup>
            </LayersControl.Overlay>
        </LayersControl>
    )
}


