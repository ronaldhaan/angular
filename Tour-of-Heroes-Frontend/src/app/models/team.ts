import { Metahuman } from './metahuman';

/** represents a meta. */
export class Team {
    id: string;
    name: string;
    description: string;
    metahumans: Metahuman[];

    public static Empty(): Team {
        return {
            id: '',
            name: '',
            description: '',
            metahumans: [],
        };
    }
}
