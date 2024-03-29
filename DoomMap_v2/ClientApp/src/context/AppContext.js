﻿import React, { createContext, Component } from "react";
import API from '../utils/api';

export const AppContext = createContext();

class AppContextProvider extends Component {

    state = {
        allFires: [],
        allDroughts: [],
        allAreas: [],
        allStorms: [],
        stormTrackLine: [],
        stormTrackPgn: [],
        stormTrackPts: [],
        historicalData: null,
        numberFires: null,
        numberDroughts: null,
        totalDailyAcres: null,
        acresDroughts: null
    }


    getFeatureData = () => {


        API.getAllFires()
            .then(response => response.json())
            .then(data => {
                    this.setState({ allFires: data })
            })
            .catch(err => console.log(err));

        API.getDroughtConditions()
            .then(response => response.json())
            .then(data => {
                this.setState({ allDroughts: data })
            })
            .catch(err => console.log(err))

        API.getAdvisoryAreas()
            .then(response => response.json())
            .then(data => {
                this.setState({ allAreas: data })
            })
            .catch(err => console.log(err))

        API.getStormConditions()
            .then(response => response.json())
            .then(data => {
                    this.setState({ allStorms: data })
            })
            .catch(err => console.log(err))


        API.getStormTrack("line")
            .then(response => response.json())
            .then(data => {
                this.setState({ stormTrackLine: data })
            })
            .catch(err => console.log(err));

        API.getStormTrack("pgn")
            .then(response => response.json())
            .then(data => {
                this.setState({ stormTrackPgn: data })
            })
            .catch(err => console.log(err));

        API.getStormTrack("pts")
            .then(response => response.json())
            .then(data => {
                this.setState({ stormTrackPts: data })
            })
            .catch(err => console.log(err));      
            
    }


    updateDisasterMetrics = (boundingCoords) => {

        const polyCoords = {
            xmin: boundingCoords['_southWest']['lng'],
            ymin: boundingCoords['_southWest']['lat'],
            xmax: boundingCoords['_northEast']['lng'],
            ymax: boundingCoords['_northEast']['lat']
        }


        API.getMetricsInBounds(polyCoords).then(response => response.json())
            .then(data => {
                console.log("metrics: ", data)
                this.setState({ numberFires: data.numberFires })
                this.setState({ totalDailyAcres: data.totalDailyAcres })
                this.setState({ numberDroughts: data.numberDroughts })
                this.setState({ acresDroughts: data.acresDroughts })

            }).catch(err => console.log(err));

        //API.getAreasInBounds(polyCoords).then(response => response.json())
        //    .then(data => {
        //        setViewAreas(data)
        //    }).catch(err => console.log(err));

        //API.getStormsInBounds(polyCoords).then(response => response.json())
        //    .then(data => {
        //        setViewStorms(data)
        //    }).catch(err => console.log(err));

    }




    render() {

        return (
            <AppContext.Provider value={{
                allFires: this.state.allFires,
                allDroughts: this.state.allDroughts,
                updateDisasterMetrics: this.updateDisasterMetrics,
                getFeatureData: this.getFeatureData,
                numberFires: this.state.numberFires,
                totalDailyAcres: this.state.totalDailyAcres,
                numberDroughts: this.state.numberDroughts,
                acresDroughts: this.state.acresDroughts,
                allAreas: this.state.allAreas,
                allStorms: this.state.allStorms,
                stormTrackLine: this.state.stormTrackLine,
                stormTrackPgn: this.state.stormTrackPgn,
                stormTrackPts: this.state.stormTrackPts

            }}>
                {this.props.children}
            </AppContext.Provider>
        );
    }
}

export default AppContextProvider;