using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanFusion_BE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetAudience = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StoryId = table.Column<int>(type: "integer", nullable: false),
                    SaveAsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chapters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryTag",
                columns: table => new
                {
                    StoriesId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryTag", x => new { x.StoriesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_StoryTag_Stories_StoriesId",
                        column: x => x.StoriesId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Romance" },
                    { 2, "Adventure" },
                    { 3, "Fantasy" },
                    { 4, "Science Fiction" },
                    { 5, "Mystery" },
                    { 6, "Thriller" },
                    { 7, "Supernatural" },
                    { 8, "Slice of Life" },
                    { 9, "Horror" },
                    { 10, "Historical Fiction" },
                    { 11, "Humor" },
                    { 12, "Drama" },
                    { 13, "Fanfiction" },
                    { 14, "Crossover" },
                    { 15, "Fluff" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Magic" },
                    { 2, "Adventure" },
                    { 3, "Friendship" },
                    { 4, "Space" },
                    { 5, "Sci-Fi" },
                    { 6, "Romance" },
                    { 7, "Mystery" },
                    { 8, "Supernatural" },
                    { 9, "Fantasy" },
                    { 10, "Betrayal" },
                    { 11, "Music" },
                    { 12, "Healing" },
                    { 13, "Travel" },
                    { 14, "Politics" },
                    { 15, "Competition" },
                    { 16, "Slice of Life" },
                    { 17, "Dark Fantasy" },
                    { 18, "Time Travel" },
                    { 19, "High Stakes" },
                    { 20, "Self-Discovery" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "https://example.com/images/john.jpg", "Doe", "user001", "john_doe" },
                    { 2, "jane@example.com", "Jane", "https://example.com/images/jane.jpg", "Smith", "user002", "jane_smith" },
                    { 3, "alice@example.com", "Alice", "https://example.com/images/alice.jpg", "Johnson", "user003", "alice_johnson" },
                    { 4, "bob@example.com", "Bob", "https://example.com/images/bob.jpg", "Brown", "user004", "bob_brown" },
                    { 5, "charlie@example.com", "Charlie", "https://example.com/images/charlie.jpg", "Davis", "user005", "charlie_davis" },
                    { 6, "eve@example.com", "Eve", "https://example.com/images/eve.jpg", "Wilson", "user006", "eve_wilson" },
                    { 7, "dave@example.com", "Dave", "https://example.com/images/dave.jpg", "Martinez", "user007", "dave_martinez" },
                    { 8, "fiona@example.com", "Fiona", "https://example.com/images/fiona.jpg", "Taylor", "user008", "fiona_taylor" },
                    { 9, "george@example.com", "George", "https://example.com/images/george.jpg", "Anderson", "user009", "george_anderson" },
                    { 10, "hannah@example.com", "Hannah", "https://example.com/images/hannah.jpg", "Thomas", "user890", "hannah_thomas" },
                    { 11, "ian@example.com", "Ian", "https://example.com/images/ian.jpg", "Jackson", "user567", "ian_jackson" },
                    { 12, "jack@example.com", "Jack", "https://example.com/images/jack.jpg", "White", "user234", "jack_white" },
                    { 13, "kathy@example.com", "Kathy", "https://example.com/images/kathy.jpg", "Garcia", "user789", "kathy_garcia" },
                    { 14, "liam@example.com", "Liam", "https://example.com/images/liam.jpg", "Martinez", "user456", "liam_martinez" },
                    { 15, "mia@example.com", "Mia", "https://example.com/images/mia.jpg", "Hernandez", "user123", "mia_hernandez" }
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "Image", "TargetAudience", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A time-travel story where Harry returns to his first year to fix everything.", "https://example.com/images/hogwarts.jpg", "Young Adult", "A Second Chance at Hogwarts", 15 },
                    { 2, 4, new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two rival bounty hunters must work together to survive an intergalactic chase.", "https://example.com/images/galactic.jpg", "New Adult", "Galactic Refuge", 14 },
                    { 3, 1, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A romance between a concert violinist and the mysterious pianist next door.", "https://example.com/images/heartstrings.jpg", "Adult", "Heartstrings", 13 },
                    { 4, 11, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A detective with a love for pranks solves cases with humor.", "https://example.com/images/detective.jpg", "Young Adult", "The Laughing Detective", 12 },
                    { 5, 7, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "An exiled prince returns to reclaim his haunted castle.", "https://example.com/images/castle.jpg", "New Adult", "Castle of Shadows", 11 },
                    { 6, 4, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A group of teenagers discovers a portal to a parallel world.", "https://example.com/images/abyss.jpg", "Young Adult", "Into the Abyss", 10 },
                    { 7, 8, new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "A series of heartwarming meetings at a small-town coffee shop.", "https://example.com/images/cafe.jpg", "Adult", "Café Encounters", 1 },
                    { 8, 7, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "A ghost helps a troubled author find peace through her writing.", "https://example.com/images/whispers.jpg", "New Adult", "Whispers in the Dark", 2 },
                    { 9, 14, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A villain falls in love with the hero sworn to defeat them.", "https://example.com/images/heroes.jpg", "Young Adult", "Heroes and Villains", 3 },
                    { 10, 10, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Old letters reveal a forgotten love story between two soldiers.", "https://example.com/images/letters.jpg", "Adult", "Letters from the Past", 4 },
                    { 11, 3, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A warrior prepares for a final battle, haunted by visions of the future.", "https://example.com/images/stand.jpg", "New Adult", "The Last Stand", 5 },
                    { 12, 11, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mix-up at a royal wedding leads to a cascade of hilarious events.", "https://example.com/images/comedy.jpg", "Young Adult", "Comedy of Errors", 6 },
                    { 13, 12, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two writers leave coded messages for each other in their novels.", "https://example.com/images/lines.jpg", "Adult", "Between the Lines", 7 },
                    { 14, 7, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "A secret train only appears to those in need of second chances.", "https://example.com/images/express.jpg", "Young Adult", "The Midnight Express", 8 },
                    { 15, 4, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A scientist and an artist explore love across multiple dimensions.", "https://example.com/images/paths.jpg", "New Adult", "Parallel Paths", 9 }
                });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "Content", "DateCreated", "SaveAsDraft", "StoryId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Harry stood at the entrance to Hogwarts once more, the weight of his past decisions heavy on his mind. This time, he vowed, things would be different. The Sorting Hat sensed his presence even before he entered the Great Hall. ‘Ah, Potter,’ it whispered, low enough for only him to hear. ‘I see you’ve come for another chance. But fate has a funny way of twisting, doesn’t it?’ Harry hesitated, remembering how his choice to be in Gryffindor had set everything in motion. What if he had chosen differently? The hat grinned in his mind. ‘Perhaps this time, I’ll put you where you belong...’ As the feast continued, Harry’s heart raced. He knew that some choices were never meant to be undone, and now the Sorting Hat’s words haunted him. Maybe the real battle was never with Voldemort, but with himself.", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "The Sorting Hat's Secret", 15 },
                    { 2, "The cold metal walls of the starship echoed with each step as Vera checked her blaster. Beside her, Jax smirked. ‘You know, we could’ve walked away from this one.’ ‘And let them take the payout? Not a chance.’ The ship lurched violently as enemy fire hit the hull, and both bounty hunters stumbled but recovered quickly. They were being hunted themselves now. Jax’s hand hovered over the console. ‘We can jump now, or we stay and fight.’ Vera glanced at the radar—a swarm of ships were closing in fast. She didn’t trust Jax, not fully. But trust wouldn’t matter if they didn’t survive the next ten minutes. ‘Jump,’ she said finally, and Jax’s grin widened as the ship slipped into hyperspace, leaving the danger—and perhaps her better judgment—behind.", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "A Bounty Too Far", 14 },
                    { 3, "It was nearly midnight when the knock came. Emma stirred in bed, unsure if it was part of her dream. The knock came again, soft but insistent. Slowly, she slipped out of bed, heart pounding, and tiptoed to the door. A folded piece of paper slid through the crack at the bottom just as she reached it. She hesitated before picking it up, unfolding the note with shaky hands. ‘Meet me by the river at midnight,’ it read. The handwriting was messy, hurried, almost as if the writer had little time. Emma felt a strange tug in her chest—a feeling she couldn’t quite explain. She threw on her coat and hurried out into the cold night. At the river, she saw him waiting, his violin case slung over his shoulder. ‘You came,’ he whispered, as if he hadn’t believed she would. Emma nodded, her breath visible in the chilly air. And just like that, two lives that had drifted apart began to weave a song only they could hear.", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, "The Note Beneath the Door", 13 },
                    { 4, "Detective Blake wasn’t one for mysteries involving kitchenware, but this was no ordinary spoon. ‘It vanished right off the table,’ the witness claimed, eyes wide with disbelief. Blake examined the room, noting the odd layout—too many spoons in the drawer, and one missing from the pristine display. His partner chuckled. ‘You’re really going to crack this one, aren’t you?’ ‘A spoon doesn’t just vanish,’ Blake muttered, crouching down to inspect the floorboards. It was then he noticed a faint groove along the edge—a hidden compartment. With a grin, Blake pried it open, revealing not just the spoon, but a stack of stolen jewels hidden beneath it. ‘Looks like this case just went from silverware to grand theft,’ he said with a smirk, holding up the glittering evidence. His partner shook her head, laughing. ‘Only you could solve a crime like this.’", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, "The Case of the Vanishing Spoon", 12 },
                    { 5, "The ancient throne loomed at the center of the darkened hall, its surface etched with symbols no living soul could decipher. Prince Aldric approached it cautiously, his sword drawn. The old tales warned of the curse: the first heir to sit on the throne would inherit the sins of the past kings. The air was thick with the scent of old incense, and shadows flickered as if alive. ‘There is no turning back,’ he whispered to himself. As Aldric sat, the throne groaned beneath his weight, and a deep, ancient voice echoed through the room. ‘Do you seek power, boy? Or redemption?’ Aldric closed his eyes, knowing that to claim one, he would have to sacrifice the other.", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, "The Haunted Throne", 11 },
                    { 6, "The portal closed with a shimmer, leaving Emily stranded in a realm she did not recognize. The sky above was a swirling canvas of colors, and the ground beneath her felt like it was made of glass. Strange creatures darted through the air, their shapes shifting with every movement. Clutching her pendant, Emily knew it was her only way back—but it flickered weakly, as if the magic within was almost spent. With every step she took deeper into the abyss, the whispers grew louder, urging her to stay. But she couldn’t. She had to find her way home before the last light of the pendant faded forever.", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, "Lost in the Abyss", 10 },
                    { 7, "Amara knew she shouldn’t have come back, but the memories of him haunted her every step. She found Theo waiting at the same café they used to visit as teenagers. Time had aged them both, but the fire in his eyes remained the same. ‘I thought you forgot about me,’ Theo said quietly, stirring his coffee. ‘I tried,’ Amara admitted. ‘But you’re impossible to forget.’ They spent hours talking about everything and nothing, as if the years between them were mere minutes. And when Theo reached for her hand across the table, Amara knew some love stories were meant to start over.", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, "A Love Rekindled", 13 },
                    { 8, "Nina’s fingers hovered over the piano keys, the weight of the unfinished symphony pressing down on her. This was the last song she would ever play for him. With a deep breath, she let the music flow from her heart, each note telling the story of love, loss, and hope. As the melody reached its peak, tears blurred her vision. But she played on, knowing that this was how she would say goodbye. The final chord lingered in the air, a bittersweet farewell to the past and a step toward an unknown future.", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, "The Final Melody", 14 },
                    { 9, "Max had always known that in the corporate world, loyalty was a currency few could afford. But this time, the betrayal came from someone he least expected—his business partner. With the merger on the line, Max found himself at a crossroads: expose the betrayal and risk losing everything, or play along and win the game. He stared at the contract in front of him, knowing that signing it would change his life forever. But sometimes, in the world of high stakes, the only way to win was to lose.", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, "The Business of Betrayal", 10 },
                    { 10, "Dr. Lila Monroe believed in miracles, but she never thought she would be one. Her clinic in the heart of the city served patients no one else wanted. And when a mysterious patient arrived with a condition Lila had never seen, she knew she was about to be tested in ways she never imagined. The man’s fevered words hinted at a story far more dangerous than any disease. And as Lila fought to save his life, she realized that healing wasn’t just about the body—it was about mending hearts, too.", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, "Healing Hands", 11 },
                    { 11, "With nothing but a backpack and a map, Leo set off on an adventure across the world. Every city, every stranger, every road taught him something new about himself. But the journey wasn’t just about seeing new places—it was about finding his way back to the person he used to be. And somewhere between the mountains and the sea, Leo discovered that sometimes, the greatest destination was coming home.", new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 11, "Wanderlust", 12 },
                    { 12, "In a world where political ambition came with a cost, Senator Quinn had always known he would have to pay. But when a secret from his past threatened to ruin everything, he found himself on the brink of losing not only his career but also the people he loved. With the clock ticking, Quinn had to decide: would he cling to power, or would he choose the one thing money couldn’t buy—redemption?", new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, "The Price of Power", 15 },
                    { 13, "The crowd roared as Jade crossed the finish line, her heart pounding with triumph. But victory wasn’t just about winning the race—it was about proving to herself that she could. For every mile, every setback, and every doubt, Jade had fought to be here. And as the confetti rained down, she realized that sometimes, the hardest race was the one you ran against yourself.", new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 13, "Victory Lap", 14 },
                    { 14, "The festival was a riot of colors, sounds, and flavors, each booth telling the story of a different culture. For Maya, it was a chance to reconnect with her roots—and with the father she hadn’t seen in years. As they walked through the festival together, sharing food and memories, Maya realized that family wasn’t just about blood—it was about the stories they carried with them.", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, "Cultural Mosaic", 13 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ChapterId", "Content", "CreatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I love the twist on Harry's choices! It really makes me think about fate.", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 2, 2, "Vera and Jax have such great chemistry! Can't wait to see what happens next.", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 3, 3, "The suspense in this chapter is intense! What will Emma do next?", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 4, 4, "This mystery is captivating! I can't believe the spoon was hiding jewels!", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 5, 5, "Aldric's struggle with the throne is fascinating! Will he choose power or redemption?", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 6, 6, "Emily's journey through the abyss sounds incredible! I hope she finds her way back.", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 7, 7, "Amara and Theo's reunion gives me all the feels! Can't wait for more.", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 8, 8, "Nina's last performance is heartbreaking! What a way to say goodbye.", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 9, 9, "Max's dilemma in the corporate world is so relatable! What a tough choice.", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 10, 10, "Dr. Monroe's story is inspiring! Healing goes beyond just physical health.", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 11, 11, "Leo's adventure sounds exhilarating! Can't wait to see where it takes him.", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 12, 12, "Senator Quinn's struggles with power are gripping! This story has me on edge.", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 13, 13, "Jade's victory is so empowering! Love this journey of self-discovery.", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 14, 14, "The festival's cultural richness is beautifully portrayed! Great family bonding.", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_StoryId",
                table: "Chapters",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_UserId",
                table: "Chapters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ChapterId",
                table: "Comments",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_CategoryId",
                table: "Stories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_UserId",
                table: "Stories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryTag_TagsId",
                table: "StoryTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "StoryTag");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
