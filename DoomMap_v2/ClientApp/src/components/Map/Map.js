import React, { useEffect, useState, useCallback, useContext } from 'react';
import { styled } from '@mui/material/styles';
import { MapContainer, TileLayer } from 'react-leaflet';
import { useMap } from 'react-leaflet/hooks'
import L from 'leaflet';
import "leaflet/dist/leaflet.css";
import Metrics from '../Metrics/Metrics';
import AppContextProvider, { AppContext } from '../../context/AppContext';
import MapLayers from './MapLayers';

export default function Map() {

    const { updateDisasterMetrics, getFeatureData } = useContext(AppContext);


    function DisplayPosition() {
        const map = useMap()

        const [viewPosition, setPosition] = useState(map.getCenter())
        const [viewBounds, setViewBounds] = useState(map.getBounds())

        const onMove = useCallback(() => {

            let bounds = map.getBounds();
            let position = map.getCenter();

            if (bounds !== viewBounds || position !== viewPosition) {
                setPosition(position)
                setViewBounds(bounds)
                updateDisasterMetrics(bounds);
            }

        }, [map])

        useEffect(() => {
            map.on('move', onMove)

            return () => {
                map.off('move', onMove)
            }
        }, [map, onMove])

        return (
            <Metrics viewBounds={viewBounds} />
        )
    }

    useEffect(() => {

        getFeatureData();

    }, [])



    return (
        <div>

            <MapContainer
                center={[40.4958869189588, -99.2314387964737]}
                zoom={4}
                style={{ height: '100vh' }}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                <DisplayPosition />
                <MapLayers />
            </MapContainer>
        </div>

    );

}

