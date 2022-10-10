import Box from "@mui/material/Box";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import FolderIcon from "@mui/icons-material/Folder";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import Avatar from "@mui/material/Avatar";
import IconButton from "@mui/material/IconButton";
import EditIcon from '@mui/icons-material/Edit';

export default function BasicList() {
    const locations = ["Home", "Garage"];

    return (
        <Box sx={{ width: "100%", bgcolor: "background.paper" }}>
            <nav aria-label="main mailbox folders">
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
                            <ListItemButton>
                                <ListItemAvatar>
                                    <Avatar>
                                        <FolderIcon />
                                    </Avatar>
                                </ListItemAvatar>
                                <ListItemText primary={location} />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </List>
            </nav>
        </Box>
    );
}
