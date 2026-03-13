# AR Knick-Knack Project

This project contains two AR knick-knacks: one for Armenia (Etchmiadzen Cathedral) and one for Sohar, Oman.  
The goal was to create small AR objects that display meaningful scenes and dynamic features, including time, weather, and interactive elements.

---

## Level 1 – Armenia Knick-Knack

- I chose Armenia because it was a very formative trip for me during the winter break of my sophomore year.  
- The religiosity of the people deeply impacted me, so I selected the Etchmiadzen Cathedral as the main model for my first knick-knack.  
- Creating the merge cube itself took about an hour due to my initial struggle with Vuforia.  
- On top of the merge cube, I added:
  - The cathedral model
  - Two old-looking trees from Sketchfab
  - Sun and clouds created in Blender and imported as FBX
- I added a church bell sound to highlight the orthodoxy of the place.  
- A directional light was included to give the scene a soft afternoon glow.

---

## Level 2 – Dynamic Text

- Successfully added all required information displays:
  - One side shows the name of the cathedral in Armenian  
  - Other sides show local time and weather, updating automatically

---

## Level 3 – Oman Knick-Knack

- My first knick-knack caused camera issues, so I created a new Unity project to present a functional version.  
- The second knick-knack represents Sohar, Oman, where I lived in high school — this location holds personal significance.  
- The scene mirrors the Armenian knick-knack layout, with models representing Oman’s desert, sun, and clouds.

---

## Level 4 – Time & Weather-Based Changes

- The sun and clouds appear dynamically depending on time of day and weather conditions at the location.  
- Objects were created in Blender and imported as FBX into Unity.  
- Weather and time data are fetched via the OpenWeatherMap API, updating the cube text every 10 minutes.

---

## Level 5 – User Interaction

- Inspired by mirages on Middle Eastern roads, a feature was added where:
  - Certain text appears on the cube only when tilted beyond 30° on any side  
- This demonstrates a user-triggered scene change without relying on clicks or distance calculations.

---

## Technical Notes

- Unity Version: Latest stable version with Vuforia  
- Scripts Used:
  - Weather and time updater  
  - Info text updater for Oman  
  - Tilt-based user interaction for Level 5
- Assets Imported:  
  - Models from Sketchfab  
  - Blender FBX files for sun and clouds  
  - Audio: Church bell for Armenian scene
- Challenges:
  - Camera conflicts required creating a new project  
  - Learning curve for Vuforia tracking and mesh/material import  
  - Troubleshooting text visibility and particle systems

---

## Conclusion

This project was both technically and personally meaningful.  
The Armenia knick-knack reflects a formative travel experience, while the Oman knick-knack represents childhood memories. Despite technical difficulties, the project demonstrates dynamic scene elements, API-driven data, and interactive features, showing the potential of AR knick-knacks in personal and educational contexts.

---

## Credits

- Yerevan church drone.wav  
  - Overall rating: 6 ratings, January 7th, 2016  
  - Soundscapes > Urban  
  - Church drone, Yerevan, Armenia, cathedral dome, church-bells ringing  

- 3D Models:
  - ["Old Tree"](https://skfb.ly/6TvHn) by gelmi.com.br – [CC Attribution 4.0](http://creativecommons.org/licenses/by/4.0/)  
  - ["Church of Saint Gregory"](https://skfb.ly/p9r6Z) by Azad Balabanian – [CC Attribution 4.0](http://creativecommons.org/licenses/by/4.0/)  
  - ["Realistic Palm Tree Free"](https://skfb.ly/prWT9) by Next Spring – [CC Attribution 4.0](http://creativecommons.org/licenses/by/4.0/)  
  - ["Desert Fortress Tower"](https://skfb.ly/pAMvx) by Ishxxn – [CC Attribution 4.0](http://creativecommons.org/licenses/by/4.0/)  
  - ["Minaret V2"](https://skfb.ly/pGH6p) by Ishxxn – [CC Attribution 4.0](http://creativecommons.org/licenses/by/4.0/)
