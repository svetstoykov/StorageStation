import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import HomeIcon from '@mui/icons-material/Home';
import ListItemAvatar from "@mui/material/ListItemAvatar";
import Avatar from "@mui/material/Avatar";
import IconButton from "@mui/material/IconButton";
import EditIcon from "@mui/icons-material/Edit";
import { Link } from "react-router-dom";

export default function BasicList() {
    const locations = ["Home", "Garage"];

    return (
        <List>
            {locations.map((location) => (
                <ListItem
                    disablePadding
                    secondaryAction={
                        <IconButton edge="end" aria-label="delete">
                            <EditIcon />
                        </IconButton>
                    }
                >
                    <ListItemButton component={Link} to={"/storedItems"}>
                        <ListItemAvatar>
                            <Avatar>
                                <HomeIcon />
                            </Avatar>
                        </ListItemAvatar>
                        <ListItemText primary={location} />
                    </ListItemButton>
                </ListItem>
            ))}
        </List>
    );
}
