import { HttpHeaders } from "@angular/common/http";

export const UTILITIES = {
    apiServerUrl: "https://localhost:44393",
    httpOptions: {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    },
}