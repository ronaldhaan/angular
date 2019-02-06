import { Hero } from './models/hero';

/** List of all heroes */
export const HEROES: Hero[] = [
    {
        id: 1,
        name: 'Batman',
        abilities: [
            {
                name: 'rich',
                description: 'with his money he makes special tools to fight with',
            },
            {
                name: 'martial art',
                description: '',
            },
        ]
    },{
        id: 2,
        name: 'Superman',
        abilities: [
            {
                name: 'super strength',
                description: 'unbeatable with this ability',
            },
            {
                name: 'heat vision',
                description: 'laserbeams out of his eyes',
            },
        ]
    },{
        id: 3,
        name: 'Wonderwoma',
        abilities: [
            {
                name: 'fly',
                description: '',
            },
            {
                name: 'swordswoman',
                description: 'a master with a sword',
            },
        ]
    },{
        id: 4,
        name: 'The Flash',
        abilities: [
            {
                name: 'superspeed',
                description: 'faster than light',
            },
        ]
    },
]