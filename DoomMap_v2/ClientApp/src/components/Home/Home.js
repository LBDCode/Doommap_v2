import React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Container from '@mui/material/Container';
import heroOverlay from './landing.PNG';
import { Typography } from '@mui/material';
import Button from '@mui/material/Button';
import Icon from '@mdi/react'
import { mdiHomeFlood, mdiAlienOutline, mdiWeatherHurricane, mdiFire } from '@mdi/js'


export default function Home() {



    const HomeContainer = styled('div')({
        position: 'absolute',
        width: '100%',
        top: '90px',
        height: 'calc(100vh - 90px)',
        backgroundColor: '#111',
    });


    const HeroContainer = styled(Container)({
        height: '60vh',
        minHeight: '360px',
        maxHeight: '600px',
        marginTop: '60px',
        backgroundColor: '#212529',
        padding: '8% 20% 20% 5%',
        paddingBottom: '140px!important',
        position: 'relative',
        zIndex: '3000',
        '&::after': {
            content: "''",
            backgroundImage: `url(${heroOverlay})`,
            backgroundSize: 'cover',
            position: 'absolute',
            top: '0px',
            right: '0px',
            bottom: '0px',
            left: '0px',
            opacity: '0.21',
            zIndex: '3000',
        }
    });

    const HeroContent = styled('div')({
        maxWidth: '520px',
        textAlign: 'right'

    })

    const HeroButton = styled(Button)({
        marginTop: '40px',
        marginRight: '20px',
        zIndex: '10000',
        boxShadow: 'none',
        textTransform: 'none',
        fontSize: '1.2rem',
        padding: '8px 18px',
        border: '2px solid',
        lineHeight: 1.5,
        backgroundColor: '#ff630700',
        borderColor: '#d0550d',
        color: '#d0550d',
        '&:hover': {
            backgroundColor: '#d0550d',
            borderColor: '#d0550d',
            boxShadow: 'none',
            color: '#fff'
        },
        '&:active': {
            boxShadow: 'none',
            backgroundColor: '#d0550d',
            borderColor: '#d0550d',
            color: '#fff'

        },
        '&:focus': {
            boxShadow: '0 0 0 0.2rem rgba(0,123,255,.5)',
            color: '#fff'
        },
    });



    //const NavDesktopSection = styled('div')(({ theme }) => ({
    //    display: 'none',
    //    [theme.breakpoints.up('md')]: {
    //        display: 'flex',
    //    },

    //}));


    const LargeHeroText = styled(Typography)({
        color: "#fff!important",
        fontWeight: '700!important',
        fontSize: '2rem!important',
        textAlign: 'right',
    });


    const IconGridContainer = styled(Container)({
        marginTop: '7vh',
        backgroundColor: '#111'

    });

    const IconGridItem = styled(Grid)({
        textAlign: 'center!important'

    });



    return (
        <HomeContainer>
            <HeroContainer maxWidth={false}>
                <HeroContent>
                    <LargeHeroText variant="h5" paragraph>
                        <span>So, what's dooming the United </span>
                        <span>States today?</span>
                    </LargeHeroText>

                    <HeroButton variant="outlined" href="/map">
                        Let's find out!
                    </HeroButton>
                </HeroContent>
            </HeroContainer>
            <IconGridContainer maxWidth={false} >
                <Grid container spacing={4}>
                    <IconGridItem item key={1} xs={3} >
                        <Icon path={mdiFire}
                            size={'3.8rem'}
                            color="#495057" />
                    </IconGridItem>
                    <IconGridItem item key={2} xs={3} >
                        <Icon path={mdiWeatherHurricane}
                            size={'3.8rem'}
                            color="#495057" />
                    </IconGridItem>
                    <IconGridItem item key={3} xs={3}>
                        <Icon path={mdiHomeFlood}
                            size={'3.8rem'}
                            color="#495057" />
                    </IconGridItem>
                    <IconGridItem item key={4} xs={3} >
                        <Icon path={mdiAlienOutline}
                            size={'3.8rem'}
                            color="#495057" />
                    </IconGridItem>
                </Grid>
            </IconGridContainer>
        </HomeContainer>

    );

}

