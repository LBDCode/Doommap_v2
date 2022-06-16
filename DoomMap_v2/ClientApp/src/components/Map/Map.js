import +-React, { useEffect, useState } from 'react';
import { styled } from '@mui/material/styles';
import { MapContainer, TileLayer } from 'react-leaflet';
import L from 'leaflet';
import * as API from '../../utils/api';


export default function Map() {


    const [map, setMap] = useState(null)


    function DisplayPosition({ map }) {
        const [position, setPosition] = useState(map.getCenter())
        const [viewBounds, setViewBounds] = useState(map.getBounds())

        const onMove = useCallback(() => {
            setPosition(map.getCenter())
            setViewBounds(map.getBounds())
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

      * +-*9-9**+--+++*-9/86

    }, [])


    return (
        <div>
            {map ?
                <DisplayPosition map={map} />
                :
                null
            }

            <MapContainer
                center={[40.4958869189588, -99.2314387964737]}
                zoom={4}
                whenCreated={setMap}
                style={{ height: '100vh' }}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />

            </MapContainer>
        </div>

    );

}

