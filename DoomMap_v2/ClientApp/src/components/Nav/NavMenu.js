import React, { Component, useState } from 'react';
import { Link } from "react-router-dom";
import { styled } from '@mui/material/styles';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import SvgIcon from '@mui/material/SvgIcon';
import IconButton from '@mui/material/IconButton';
import HomeOutlinedIcon from '@mui/icons-material/HomeOutlined';
import MoreVertOutlinedIcon from '@mui/icons-material/MoreVertOutlined';
import MapOutlinedIcon from '@mui/icons-material/MapOutlined';

export default function Nav(props) {

    const [anchorEl, setAnchorEl] = useState(null);
    const [mobileMoreAnchorEl, setMobileMoreAnchorEl] = useState(null);

    const isMenuOpen = Boolean(anchorEl);
    const isMobileMenuOpen = Boolean(mobileMoreAnchorEl);


    const handleMobileMenuClose = () => {
        setMobileMoreAnchorEl(null);
    };

    const handleMenuClose = () => {
        setAnchorEl(null);
        handleMobileMenuClose();
    };

    const handleMobileMenuOpen = event => {
        setMobileMoreAnchorEl(event.currentTarget);
    };

    const menuId = 'primary-search-account-menu';



    const MobileIcon = styled(SvgIcon)({
        color: '#003d59',
        marginRight: '5px',
        marginBottom: '2px'
    });


    const MobileLink = styled('span')({
        color: '#003d59',
        fontWeight: '600',
    });


    const GrowContainer = styled('div')({
        flexGrow: 1,
    });


    const NavAppBar = styled(AppBar)({
        height: '90px',
        minHeight: '90px',
        backgroundColor: '#111',
        color: '#fff'
    });


    const NavToolbar = styled(Toolbar)({
        padding: 0,
        height: '90px',
        minHeight: '90px',
    });



    const NavIconButton = styled(IconButton)({
        margin: 0,
        padding: 0

    });

    const NavDesktopSection = styled('div')(({ theme }) => ({
        display: 'none',
        [theme.breakpoints.up('md')]: {
            display: 'flex',
        },

    }));


    const NavMobileSection = styled('div')(({ theme }) => ({
        display: 'flex',
        [theme.breakpoints.up('md')]: {
            display: 'none',
        },
    }));


    const NavLeftLinks = styled(Link)({
        color: '#dee2e6;',
        fontSize: '1.8rem',
        fontWeight: '600',
        padding: '6px 20px',
        textDecoration: 'none',
        '&:hover': {
            color: '#6c757d'
        },

    });


    const NavRightLinks = styled(Link)({
        color: '#fff',
        fontSize: '1rem',
        paddingRight: '20px',
        paddingLeft: '5px',
        textDecoration: 'none',
        '&:hover': {
            color: '#6c757d'
        },


    });


    const renderMenu = (
        <Menu
            anchorEl={anchorEl}
            anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
            id={menuId}
            keepMounted
            transformOrigin={{ vertical: 'top', horizontal: 'right' }}
            open={isMenuOpen}
            onClose={handleMenuClose}
        >
            <MenuItem onClick={handleMenuClose}>Profile</MenuItem>
            <MenuItem onClick={handleMenuClose}>My account</MenuItem>
        </Menu>
    );

    const mobileMenuId = 'primary-search-account-menu-mobile';
    const renderMobileMenu = (
        <Menu
            anchorEl={mobileMoreAnchorEl}
            anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
            id={mobileMenuId}
            keepMounted
            transformOrigin={{ vertical: 'top', horizontal: 'right' }}
            open={isMobileMenuOpen}
            onClose={handleMobileMenuClose}
        >
            <MenuItem>
                <Link to={"/"} href="/">
                    <MobileIcon > <HomeOutlinedIcon /></MobileIcon ><MobileLink>HOME</MobileLink>
                </Link>
            </MenuItem>
            <MenuItem>
                <Link to={"/map"} href="/map">
                    <MobileIcon > <MapOutlinedIcon /></MobileIcon ><MobileLink>MAP</MobileLink>
                </Link>
            </MenuItem>
        </Menu>
    );



    return (
        <GrowContainer >
            <NavAppBar position="static" >
                <NavToolbar >
                    <NavIconButton
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                    >
                    </NavIconButton>
                    <NavIconButton
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                    >
                    </NavIconButton>
                    <NavLeftLinks to={"/"} href="/"> The Doom Map </NavLeftLinks>
                    <GrowContainer />
                    <NavDesktopSection>
                        <NavRightLinks  to={"/"} href="/">Home</NavRightLinks>
                        <NavRightLinks  to={"/map"} href="/map">Map</NavRightLinks>
                    </NavDesktopSection>
                    <NavMobileSection>
                        <IconButton
                            aria-label="show more"
                            aria-controls={mobileMenuId}
                            aria-haspopup="true"
                            onClick={handleMobileMenuOpen}
                            color="inherit"
                        >
                            <MoreVertOutlinedIcon />
                        </IconButton>
                    </NavMobileSection>
                </NavToolbar>
            </NavAppBar>
            {renderMobileMenu}
            {renderMenu}
        </GrowContainer>
    );
}
