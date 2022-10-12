import * as React from "react";
import Box from "@mui/material/Box";
import SwipeableDrawer from "@mui/material/SwipeableDrawer";
import SideMenuDrawerList from "./SideMenuDrawerList";

interface Props {
    toggleDrawer: (state: boolean) => void,
    sideDrawerVisible: boolean
}

export default function SwipeableTemporaryDrawer({toggleDrawer, sideDrawerVisible}: Props) {
    return (
        <React.Fragment>
            <SwipeableDrawer
                anchor="left"
                open={sideDrawerVisible}
                onClose={() => toggleDrawer(false)}
                onOpen={() => toggleDrawer(true)}
            >
                <Box
                    sx={{ width: 250 }}
                    role="presentation"
                    onClick={() => toggleDrawer(false)}
                    onKeyDown={() => toggleDrawer(false)}
                >
                    <SideMenuDrawerList />
                </Box>
            </SwipeableDrawer>
        </React.Fragment>
    );
}
