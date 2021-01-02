x

# Game Design

# Document

## Run and

## Gun

```
Fuhgeddaboutit Gaming
```
```
Written by:
Christian Vargas-Polo
Arielle B. Watson
Titus Wen
Michael Fertig
```
```
December 18 , 2020
```

```
Game Hosted At : https://fuhgeddaboutit-gaming.github.io/ContraGame/Run%20&%20Gun/
```
<a href="https://fuhgeddaboutit-gaming.github.io/ContraGame/Run%20&%20Gun/" Game>
## Game Narrative

**I. Main Character: Alex Stark**

Alex Stark is a 30-year-old retired military veteran. He joined the
military primarily to afford school after completing the minimum four
years but found that he actually appreciated the structure that
came with military life. After completing his stint in the military, Alex
enrolled in college, and decided to study biology in order to work
towards his dream of becoming a pediatrician.

Alex lives with his elder brother John and his German Shepard, Otto,
in his brother’s three-bedroom condo in Washington, DC, mainly
because it saves money and it’s close to campus. In addition to
being a full-time student, Alex works part-time at BioCorp, a
privately-owned laboratory, in order to gain experience for his
medical school resume.

**II. Back Story**

Most days at the laboratory were pretty dull, but one day, as Alex
was helping one of the senior technicians, a code red was sounded.
As per his military training, Alex sprang into action and ran in the
direction indicated by the voice blaring over the loudspeakers. The
commotion led him to the aquarium side of the lab, where Alex
could see mutated versions of the normally gentle and encased sea
creatures breaking the aquarium glass, attacking the scientists, and
wreaking havoc in the lab. Without a moment to spare, Alex ran
quickly made his way to the secret stash of weapons that the lab
stored for emergencies and began to annihilate the mutated
creatures before they made it outside the lab.


## Gameplay Overview

**I. Main Objective**

In “Run and Gun” (R&G), the player must help Alex defeat the
mutated aquatic animals before they can escape the laboratory. It
is appropriate for players 10 and up who are seeking an action-
meets-fiction game with a strong lead character and appropriately
challenging levels. Depending on player ability, it should take
approximately 5 – 10 minutes to complete each level, with total
gameplay averaging about one-hour minimum.

**II. Short-term Goal**

The player must shoot his way through the plethora of NPC mutated
sea creatures.

**III. Mid-term Goal**

The player must avoid the enemy NPC sea creatures.

**IV. Long-term Goal**

The player much reach the outside of the laboratory, all while
avoiding getting attacked by enemy NPCS.


## Mechanics

**I. Abilities**

The player can control Alex’s movements using the following keys:

- _D key_ : forward movement
- _A key_ : backward movement
- _B_ : shooting
- _SpaceBar_ : jump

**II. Assets and Attributes**

The primary attribute in the game are three hearts that represent
lives. When the player collides with an enemy NPC, a life is lost. The
game ends when all three lives are depleted.

The assets are the five items listed within the “Short-Term Goal”
section.

**III. Obstacles**

The obstacles are the NPC mutated octopi and crabs that the
player must dodge to avoid losing a life.


## Dynamics

**I. Required Hardware**

R&G can be played on a desktop or laptop computer that runs on

Mac OS or Windows OS and is equipped with a functional keyboard

and mouse or trackpad. The player can control Alex with the keys

noted in the “Abilities” subtopic of the “Mechanics” section.


## Game Development

**I. Development Environment**

R&G was created using C# in the Unity game engine.

**II. Development Sequence**

The following shows a tentative, unordered list of development goals

that must be accomplished to produce a playable prototype. This list

does not include playtests between the addition of new mechanics:

- Program main character movements (see “Mechanics”)
- Program tutorial level(s) and puzzles
- Program enemy NPC movements
- Implement UI
    o Health hearts
    o Start screen
    o Game over screen
    o Menu system
- Record and add music and sound effects
- Develop new levels with appropriately increased difficulty


## Aesthetics

**I. Characters, NPCs, and Assets**

Sprite sheets for the main character and enemy NPCs were

obtained for free under the protection of the Creative Commons

license from kindpng.com.

**II. Game World**

The game takes place in a lab that has been overtaken by mutated

aquatic creatures. The backdrop was obtained for free under the

Creative Commons license from spriters-resource.com.

**III. Sound Effects**

All sound effects were recorded and/or created by the team.

**IV. Music**

All music was recorded and/or created by the team.


## Images

Depicted below in no particular order are the sprites and images

used in R&G. Sources and credits for all sprites and images can be

found in the “Characters, NPCs, and Assets” subsection of the

“Aesthetics” section. All sprites have been resized for the purposes of

this document, and do not represent their actual sizes during

gameplay.

```
Figure 1 Level backdrop A
```
```
Figure 2 Level backdrop B
```

**Figure 3 Alex Stark character sprite**

```
Figure 4 Enemy NPC mutated crab
```

```
Figure 5 Enemy NPC mutated octopus
```
## State Machine Diagrams

The following figures depict the state machine diagrams for the

shooting and forward movement mechanics in R&G.

```
Figure 6 Shooting mechanic state diagram
```

**Figure 7 Move forward mechanic state diagram**


## Team Member Roles and Contributions

**Christian Vargas-Polo:** _Backend/Graphics/Specs_
Specs:

- Created the narrative alongside Arielle and Titus
- Initial outlining of the game design document
Graphics:
- Created sprites for the collectible items
- Created background music
Backend:
Worked on the main functionality and visuals of the game,
including camera, character, and monster mechanics

**Arielle Watson:** _Specs/QA_
Specs:

- Created the game design document
- Created game studio logo, play button, quit button and
    game name
- Created state machines for game mechanics
QA:
Refined scope of the game, and adjusted the document as
the game evolved

**Titus Wen:** _Backend/QA_
Backend:

- Created the Start/Game Over menu
- Created the lose condition
QA:
Refined character movement mechanics and remaining life
indicator

**Michael Fertig:** _Backend/QA_
Backend:

- Created the settings menu and audio settings
- Added additional music
QA:
Improved the main menu



