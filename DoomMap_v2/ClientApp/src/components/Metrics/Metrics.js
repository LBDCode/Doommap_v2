import React, { Component, useState, useEffect, useContext } from 'react';
import { styled } from '@mui/material/styles';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import API from '../../utils/api.js';
import { AppContext } from '../../context/AppContext';



const MetricsGrid = styled(Grid)(({ theme }) => ({
    position: "fixed",
    zIndex: "5000",
    bottom: "10px",
    padding: "4px"
}));


const MetricsItem = styled(Grid)(({ theme }) => ({
    opacity: ".8",
    textAlign: "center"
}));

const MetricsPaper = styled(Paper)(({ theme }) => ({
    backgroundColor: "#111",
    fontSize: ".9rem",
    textAlign: "center",
    padding: "10px"
}));

const MetricsLargeText = styled(Typography)(({ theme }) => ({
    color: "#fff",
    fontSize: "1.5rem",
    textAlign: "center"
}));

const MetricsSmallText = styled(Typography)(({ theme }) => ({
    color: "#fff",
    fontSize: "1.1rem",
    textAlign: "center"
}));


const Metrics = (props) => {

    const { classes } = props;

    const { updateDisasterMetrics, numberFires, totalDailyAcres, numberDroughts, acresDroughts } = useContext(AppContext);


    const [viewFires, setViewFires] = useState([])
    const [viewDroughts, setViewDroughts] = useState([])
    const [viewAreas, setViewAreas] = useState([])
    const [viewStorms, setViewStorms] = useState([])


    let formatter = Intl.NumberFormat('en', { notation: 'compact' });


    //const updateDisasterMetrics = (boundingCoords) => {

    //    const polyCoords = {
    //        xmin: boundingCoords['_southWest']['lng'],
    //        ymin: boundingCoords['_southWest']['lat'],
    //        xmax: boundingCoords['_northEast']['lng'],
    //        ymax: boundingCoords['_northEast']['lat']
    //    }

    //    console.log(polyCoords);




    //    API.getFires().then(response => response.json())
    //        .then(data => {
    //            console.log(data)
    //        }).catch(err => console.log(err));

    //    API.getFiresInBounds(polyCoords).then(response => response.json())
    //        .then(data => {
    //            console.log(data)
    //            setViewFires(data)
    //        }).catch(err => console.log(err));

    //    //API.getDroughtsInBounds(polyCoords).then(response => response.json())
    //    //    .then(data => {
    //    //        setViewDroughts(data)
    //    //    }).catch(err => console.log(err));

    //    //API.getAreasInBounds(polyCoords).then(response => response.json())
    //    //    .then(data => {
    //    //        setViewAreas(data)
    //    //    }).catch(err => console.log(err));

    //    //API.getStormsInBounds(polyCoords).then(response => response.json())
    //    //    .then(data => {
    //    //        setViewStorms(data)
    //    //    }).catch(err => console.log(err));

    //}

    //useEffect(() => {
    //    //updateDisasterMetrics(props.viewBounds)

    //}, [props.viewBounds])

    return (
        <MetricsGrid
            spacing={2}
            container
            direction="row"
            justifyContent="space-evenly"
            alignItems="center"
        >
            <MetricsItem item xs={3}>
                <MetricsPaper >
                    <MetricsLargeText variant='h3'>{numberFires ? numberFires : 0} fires in view</MetricsLargeText>
                    <MetricsSmallText>{totalDailyAcres ? totalDailyAcres : 0} acres burned</MetricsSmallText>
                </MetricsPaper>
            </MetricsItem>
            <MetricsItem item xs={3}>
                <MetricsPaper >
                    <MetricsLargeText variant='h3'>{viewStorms.length} storms in view</MetricsLargeText>
                    <MetricsSmallText>acres burned</MetricsSmallText>
                </MetricsPaper>
            </MetricsItem>
            <MetricsItem item xs={3}>
                <MetricsPaper >
                    <MetricsLargeText variant='h3'>{numberDroughts ? numberDroughts : 0} droughts in view</MetricsLargeText>
                    <MetricsSmallText>{acresDroughts ? formatter.format(acresDroughts) : 0} acres affected</MetricsSmallText>
                </MetricsPaper>
            </MetricsItem>
            <MetricsItem item xs={3}>
                <MetricsPaper >
                    <MetricsLargeText variant='h3'>{viewAreas.length} advisory areas in view</MetricsLargeText>
                    <MetricsSmallText>acres affected</MetricsSmallText>
                </MetricsPaper>
            </MetricsItem>

        </ MetricsGrid>

    )
}

export default Metrics;