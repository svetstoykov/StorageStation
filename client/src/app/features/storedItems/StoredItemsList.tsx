import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import LabelIcon from "@mui/icons-material/Label";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import Avatar from "@mui/material/Avatar";
import IconButton from "@mui/material/IconButton";
import EditIcon from "@mui/icons-material/Edit";

interface Product {
    name: string;
    quantity: number;
}

function StoredItemsList() {
    const products: Product[] = [
        {
            quantity: 5,
            name: "Apple",
        },
        {
            quantity: 1,
            name: "Juice",
        },
    ];

    return (
        <List>
            {products.map((product) => (
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
                                <LabelIcon />
                            </Avatar>
                        </ListItemAvatar>
                        <ListItemText primary={product.name} />
                    </ListItemButton>
                </ListItem>
            ))}
        </List>
    );
}

export default StoredItemsList;
